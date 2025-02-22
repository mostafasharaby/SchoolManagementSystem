using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<Course>> GetCoursesByTeacherAsync(string teacherId);
        Task<List<Classroom>> GetClassroomsByTeacherAsync(string teacherId);
        Task<List<Student>> GetStudentsInClassroomAsync(string teacherId, int classroomId);
        Task AddAssignmentToCourseAsync(string teacherId, int courseId, string assignmentName, DateTime dueDate);
        Task<List<ExamResult>> GetExamResultsByCourseAsync(string teacherId, int courseId);
    }
}
