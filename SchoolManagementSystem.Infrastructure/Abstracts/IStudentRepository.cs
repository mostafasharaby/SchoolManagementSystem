using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdResponseAsync(string studentId);
        Task EnrollStudentInCourseAsync(string studentId, int courseId);
        Task<List<Course>> GetStudentCoursesAsync(string studentId);
        Task<List<Attendance>> GetStudentAttendanceAsync(string studentId);
        Task<List<ExamResult>> GetStudentExamResultsAsync(string studentId);
        Task<List<BorrowedBook>> GetStudentBorrowedBooksAsync(string studentId);
        Task<List<Fee>> GetStudentFeeHistoryAsync(string studentId);

    }
}
