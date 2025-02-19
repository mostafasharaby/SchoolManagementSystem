using SchoolManagementSystem.Core.Features.Attendances.Commands.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.AttendanceMapping
{
    public partial class AttendanceProfile
    {
        public void AttendanceCommandMapping()
        {
            CreateMap<AttendanceDto, Attendance>();
            CreateMap<UpdateAttendanceCommand, Attendance>();
        }
    }
}
