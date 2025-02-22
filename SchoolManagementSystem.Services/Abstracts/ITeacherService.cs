using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface ITeacherService
    {
        Task<bool> AddTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacherAsync(string teacherId);
        Task<Teacher> GetTeachersByIdAsync(string teacherId);
        Task<List<Teacher>> GetTeachersAsync();
        Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<Course>> GetCoursesByTeacherAsync(string teacherId);
        Task<List<Classroom>> GetClassroomsByTeacherAsync(string teacherId);
        Task<List<Student>> GetStudentsInClassroomAsync(string teacherId, int classroomId);
        Task AddAssignmentToCourseAsync(string teacherId, int courseId, string assignmentName, DateTime dueDate);
        Task<List<ExamResult>> GetExamResultsByCourseAsync(string teacherId, int courseId);

    }
}
