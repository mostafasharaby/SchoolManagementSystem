using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Helpers;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentAsync();
        public Task<Student> GetStudentAsyncByID(int studentID);
        public Task<Student> GetStudentAsyncByIDResponse(int studentID);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int studentID);
        IQueryable<Student> GetStudentAsyncQureryable();
        IQueryable<Student> GetStudentAsyncFilter(string search);
        IQueryable<Student> GetStudentAsyncOrderd(StudentOrderingEnum order);
    }
}
