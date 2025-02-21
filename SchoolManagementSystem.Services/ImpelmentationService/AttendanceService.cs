using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public AttendanceService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;

        }
        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _validationService.ValidateStudentExistsAsync(attendance.StudentID);
            await _validationService.ValidateClassRoomExistsAsync(attendance.ClassroomID);
            await _unitOfWork.Attendances.AddAsync(attendance);
            await _unitOfWork.CompleteAsync();
        }

        //public async Task DeleteAttendanceAsync(int attendanceId)  that is another way to delete but its cons that is it make 2 calls on DB so i will use the bellow one
        //{
        //    await _validationService.ValidateAttendanceExistsAsync(attendanceId);
        //    await _unitOfWork.Attendances.DeleteByIdAsync(attendanceId);
        //    await _unitOfWork.CompleteAsync();
        //}

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

        public async Task<AttendanceSummaryDto> GetAttendanceSummaryAsync(int classroomId)
        {
            await _validationService.ValidateClassRoomExistsAsync(classroomId);
            var attendances = await _unitOfWork.Attendances.GetByClassroomAsync(classroomId);
            var summary = new AttendanceSummaryDto
            {
                ClassroomID = classroomId,
                AttendanceDate = DateTime.UtcNow,
                TotalStudents = attendances.Count,
                PresentStudents = attendances.Count(a => a.Status == "present"),
                AbsentStudents = attendances.Count(a => a.Status == "absent")
            };
            return summary;
        }

        public Task MarkAttendanceAsync(int classroomId, DateTime attendanceDate, List<StudentAttendanceDto> studentAttendances)
        {
            var attendances = studentAttendances.Select(sa => new Attendance
            {
                ClassroomID = classroomId,
                StudentID = sa.StudentID,
                Date = attendanceDate,
                Status = sa.AttendanceStatus
            }).ToList();


            var result = _unitOfWork.Attendances.AddRangeAsync(attendances);
            _unitOfWork.Attendances.SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateAttendanceAsync(Attendance attendance)
        {
            await _validationService.ValidateAttendanceExistsAsync(attendance.AttendanceID);
            await _validationService.ValidateStudentExistsAsync(attendance.StudentID);
            await _validationService.ValidateClassRoomExistsAsync(attendance.ClassroomID);

            await _unitOfWork.Attendances.UpdateAsync(attendance);
            await _unitOfWork.CompleteAsync();

            return true;
        }


    }
}
