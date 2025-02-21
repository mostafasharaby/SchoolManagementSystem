using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Student>> GetStudentsInCourseAsync(int courseId);
        Task<List<Assignment>> GetAssignmentsForCourseAsync(int courseId);
        Task<List<Exam>> GetExamsForCourseAsync(int courseId);
        Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId);
    }
}
