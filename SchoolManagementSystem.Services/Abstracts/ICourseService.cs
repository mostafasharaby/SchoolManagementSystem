using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface ICourseService
    {
        Task AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int courseId);
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<List<Course>> GetAllCoursesAsync();
        Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId);
        Task<List<Student>> GetStudentsInCourseAsync(int courseId);
        Task<List<Assignment>> GetAssignmentsForCourseAsync(int courseId);
        Task<List<Exam>> GetExamsForCourseAsync(int courseId);
    }
}
