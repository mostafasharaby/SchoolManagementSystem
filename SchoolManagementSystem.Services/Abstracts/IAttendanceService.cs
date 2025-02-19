using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IAttendanceService
    {
        Task AddAttendanceAsync(Attendance attendance);
        Task<bool> UpdateAttendanceAsync(Attendance attendance);
        Task<bool> DeleteAttendanceAsync(int attendanceId);
        Task<Attendance?> GetAttendanceByIdAsync(int attendanceId);
        Task<List<Attendance>> GetAllAttendancesAsync();
        Task MarkAttendanceAsync(int classroomId, DateTime attendanceDate, List<StudentAttendanceDto> studentAttendances);
        Task<AttendanceSummaryDto> GetAttendanceSummaryAsync(int classroomId);

    }
}
