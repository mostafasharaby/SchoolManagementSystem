using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Helpers;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentAsyncByID(string studentID);
        public Task<Student> GetStudentAsyncByIDResponse(string studentID);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> AddStudentWithImageAsync(Student student, IFormFile file);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(string studentID);
        IQueryable<Student> GetStudentAsyncQureryable();
        IQueryable<Student> GetStudentAsyncFilter(string search);
        IQueryable<Student> GetStudentAsyncOrderd(StudentOrderingEnum order);
        // new        
        Task EnrollStudentInCourseAsync(string studentId, int courseId);
        Task<List<Course>> GetStudentCoursesAsync(string studentId);
        Task<List<Attendance>> GetStudentAttendanceAsync(string studentId);
        Task<List<ExamResult>> GetStudentExamResultsAsync(string studentId);
        Task<List<BorrowedBook>> GetStudentBorrowedBooksAsync(string studentId);
        Task<List<Fee>> GetStudentFeeHistoryAsync(string studentId);
    }
}
