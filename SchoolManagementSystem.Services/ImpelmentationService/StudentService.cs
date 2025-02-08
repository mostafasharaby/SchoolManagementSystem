using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Helpers;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Services.Abstracts;
namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await _StudentRepository.GetAllStudentsAsync(); // related to studentRepository not Generic one 
        }

        public async Task<Student> GetStudentAsyncByID(int studentID)
        {
            return await _StudentRepository.GetByIdAsync(studentID);
        }

        public async Task<Student> GetStudentAsyncByIDResponse(int studentID)
        {
            return await _StudentRepository.GetStudentByIdResponseAsync(studentID);
        }

        public async Task<Student?> AddStudentAsync(Student student)
        {
            var studentExists = _StudentRepository.GetTableNoTracking()
                .Any(i => i.StudentFirstNameAr == student.StudentFirstNameAr || i.StudentFirstNameEn == student.StudentFirstNameEn);

            if (studentExists)
            {
                return null;
            }
            return await _StudentRepository.AddAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int studentID)
        {
            var deletedStudent = await _StudentRepository.GetByIdAsync(studentID);

            if (deletedStudent == null)
            {
                return false;
            }

            await _StudentRepository.DeleteAsync(deletedStudent);
            return true;
        }

        Task<Student> IStudentService.UpdateStudentAsync(Student student)
        {
            return _StudentRepository.UpdateAsync(student);
        }

        public IQueryable<Student> GetStudentAsyncQureryable()
        {
            return _StudentRepository.GetTableNoTracking().AsQueryable();
        }

        public IQueryable<Student> GetStudentAsyncFilter(string search)
        {
            return _StudentRepository.GetTableNoTracking()
                .Where(item =>
                    (item.StudentFirstNameAr != null && item.StudentFirstNameAr.Contains(search)) ||
                    (item.StudentFirstNameEn != null && item.StudentFirstNameEn.Contains(search)) ||
                    (item.StudentLastNameAr != null && item.StudentLastNameAr.Contains(search)) ||
                    (item.StudentLastNameEn != null && item.StudentLastNameEn.Contains(search))
                ).AsQueryable();
        }

        public IQueryable<Student> GetStudentAsyncOrderd(StudentOrderingEnum order)
        {
            var students = _StudentRepository.GetTableNoTracking();

            return order switch
            {
                StudentOrderingEnum.up2down => students.OrderBy(s => s.StudentID),
                StudentOrderingEnum.down2up => students.OrderByDescending(s => s.StudentID),
                StudentOrderingEnum.NameUp2Down => students.OrderBy(s => s.StudentFirstNameAr)
                                                           .ThenBy(s => s.StudentFirstNameEn),
                StudentOrderingEnum.NameDownUp => students.OrderByDescending(s => s.StudentFirstNameAr)
                                                          .ThenByDescending(s => s.StudentFirstNameEn),
                _ => students
            };
        }

    }
}
