using Microsoft.AspNetCore.Http;
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
        Task<Student> AddStudentWithImageAsync(Student student, IFormFile file);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int studentID);
        IQueryable<Student> GetStudentAsyncQureryable();
        IQueryable<Student> GetStudentAsyncFilter(string search);
        IQueryable<Student> GetStudentAsyncOrderd(StudentOrderingEnum order);
        // new        
        Task EnrollStudentInCourseAsync(int studentId, int courseId);
        Task<List<Course>> GetStudentCoursesAsync(int studentId);
        Task<List<Attendance>> GetStudentAttendanceAsync(int studentId);
        Task<List<ExamResult>> GetStudentExamResultsAsync(int studentId);
        Task<List<BorrowedBook>> GetStudentBorrowedBooksAsync(int studentId);
        Task<List<Fee>> GetStudentFeeHistoryAsync(int studentId);
    }
}
