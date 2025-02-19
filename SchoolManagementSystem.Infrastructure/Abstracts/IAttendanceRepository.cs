using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task AddRangeAsync(List<Attendance> attendances);
        Task<List<Attendance>> GetByClassroomAsync(int classroomId);

    }
}
