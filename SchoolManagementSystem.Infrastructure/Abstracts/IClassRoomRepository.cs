using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;
namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IClassRoomRepository : IGenericRepository<Classroom>
    {
        Task<List<Student>> GetStudentsInClassroomAsync(int classroomId);
        Task<List<Attendance>> GetAttendanceRecordsAsync(int classroomId);
        Task<Teacher> GetTeacherInClassroomAsync(int classroomId);
    }
}
