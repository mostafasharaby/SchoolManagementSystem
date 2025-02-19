using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<Course>> GetCoursesByTeacherAsync(int teacherId);
        Task<List<Classroom>> GetClassroomsByTeacherAsync(int teacherId);
        Task<List<Student>> GetStudentsInClassroomAsync(int teacherId, int classroomId);
        Task AddAssignmentToCourseAsync(int teacherId, int courseId, string assignmentName, DateTime dueDate);
        Task<List<ExamResult>> GetExamResultsByCourseAsync(int teacherId, int courseId);
    }
}
