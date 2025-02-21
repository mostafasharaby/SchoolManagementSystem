using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Helpers;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;
namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class StudentService : IStudentService
    {
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;

        public StudentService(IFileService fileService, IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await _unitOfWork.Students.GetAllStudentsAsync(); // related to studentRepository not Generic one 
        }

        public async Task<Student> GetStudentAsyncByID(int studentID)
        {
            return await _unitOfWork.Students.GetByIdAsync(studentID);
        }

        public async Task<Student> GetStudentAsyncByIDResponse(int studentID)
        {
            return await _unitOfWork.Students.GetStudentByIdResponseAsync(studentID);
        }


        public async Task<Student> AddStudentAsync(Student student)
        {

            //var studentExists = _unitOfWork.Students.GetTableNoTracking()
            //    .Any(i => i.StudentFirstNameAr == student.StudentFirstNameAr || i.StudentFirstNameEn == student.StudentFirstNameEn);

            //if (studentExists)
            //{
            //    return null;
            //}
            await _validationService.ValidateParentExistsAsync(student.ParentID);
            await _validationService.ValidateClassRoomExistsAsync(student.ClassroomID);

            return await _unitOfWork.Students.AddAsync(student);
        }


        public async Task<Student> AddStudentWithImageAsync(Student student, IFormFile file)
        {
            var studentExists = _unitOfWork.Students.GetTableNoTracking()
                .Any(i => i.StudentFirstNameAr == student.StudentFirstNameAr || i.StudentFirstNameEn == student.StudentFirstNameEn);

            if (studentExists)
            {
                return null!;
            }
            student.Image = await _fileService.UploadFileAsync(file, "uploads");
            if (student.Image == null)
            {
                return null!;
            }
            return await _unitOfWork.Students.AddAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int studentID)
        {
            var deletedStudent = await _unitOfWork.Students.DeleteByIdAsync(studentID);
            if (deletedStudent)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            await _validationService.ValidateStudentExistsAsync(student.StudentID);
            return await _unitOfWork.Students.UpdateAsync(student);
        }

        public IQueryable<Student> GetStudentAsyncQureryable()
        {
            return _unitOfWork.Students.GetTableNoTracking().AsQueryable();
        }

        public IQueryable<Student> GetStudentAsyncFilter(string search)
        {
            return _unitOfWork.Students.GetTableNoTracking()
                .Where(item =>
                    (item.StudentFirstNameAr != null && item.StudentFirstNameAr.Contains(search)) ||
                    (item.StudentFirstNameEn != null && item.StudentFirstNameEn.Contains(search)) ||
                    (item.StudentLastNameAr != null && item.StudentLastNameAr.Contains(search)) ||
                    (item.StudentLastNameEn != null && item.StudentLastNameEn.Contains(search))
                ).AsQueryable();
        }

        public IQueryable<Student> GetStudentAsyncOrderd(StudentOrderingEnum order)
        {
            var students = _unitOfWork.Students.GetTableNoTracking();

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

        public async Task EnrollStudentInCourseAsync(int studentId, int courseId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            await _unitOfWork.Students.EnrollStudentInCourseAsync(studentId, courseId);
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.Students.GetStudentCoursesAsync(studentId);
        }

        public async Task<List<Attendance>> GetStudentAttendanceAsync(int studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.Students.GetStudentAttendanceAsync(studentId);
        }

        public async Task<List<ExamResult>> GetStudentExamResultsAsync(int studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.Students.GetStudentExamResultsAsync(studentId);
        }

        public async Task<List<BorrowedBook>> GetStudentBorrowedBooksAsync(int studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.Students.GetStudentBorrowedBooksAsync(studentId);
        }

        public async Task<List<Fee>> GetStudentFeeHistoryAsync(int studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.Students.GetStudentFeeHistoryAsync(studentId);
        }
    }
}
