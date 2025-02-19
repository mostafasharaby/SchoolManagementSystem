using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IClassRoomService
    {
        Task AddclassRoomAsync(Classroom classroom);
        Task UpdateClassroomAsync(Classroom classroom);
        Task<bool> DeleteClassroomAsync(int classroomID);
        Task<Classroom> GetClassroomByIdAsync(int classroomID);
        Task<List<Classroom>> GetAllClassroomsAsync();
        Task<bool> AddClassroomWithStudentsAsync(Classroom classroom, List<Student> students);
        Task<List<Student>> GetStudentsInClassroomAsync(int classroomId);
        Task<List<Attendance>> GetAttendanceRecordsAsync(int classroomId);
        Task<Teacher> GetTeacherInClassroomAsync(int classroomId);

    }
}
