using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _unitOfWork.Attendances.AddAsync(attendance);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteAttendanceAsync(int attendanceId)
        {
            var check = await _unitOfWork.Attendances.DeleteByIdAsync(attendanceId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            return await _unitOfWork.Attendances.GetAllAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int attendanceId)
        {
            return await _unitOfWork.Attendances.GetByIdAsync(attendanceId);
        }

        public async Task<bool> UpdateAttendanceAsync(Attendance attendance)
        {
            var attendanceExists = await _unitOfWork.Attendances.GetByIdAsync(attendance.AttendanceID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("Borrowed Book not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(attendance.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            var classRoomExists = await _unitOfWork.Classrooms.GetByIdAsync(attendance.ClassroomID);
            if (classRoomExists == null)
            {
                throw new KeyNotFoundException("Classroom not found.");
            }

            await _unitOfWork.Attendances.UpdateAsync(attendance);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
