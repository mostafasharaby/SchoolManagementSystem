using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface ITeacherService
    {
        Task<bool> AddTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacherAsync(int teacherId);
        Task<Teacher> GetTeachersByIdAsync(int teacherId);
        Task<List<Teacher>> GetTeachersAsync();
        Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<Course>> GetCoursesByTeacherAsync(int teacherId);
        Task<List<Classroom>> GetClassroomsByTeacherAsync(int teacherId);
        Task<List<Student>> GetStudentsInClassroomAsync(int teacherId, int classroomId);
        Task AddAssignmentToCourseAsync(int teacherId, int courseId, string assignmentName, DateTime dueDate);
        Task<List<ExamResult>> GetExamResultsByCourseAsync(int teacherId, int courseId);

    }
}
