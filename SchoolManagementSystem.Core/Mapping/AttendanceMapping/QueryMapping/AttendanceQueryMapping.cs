using SchoolManagementSystem.Core.Features.Attendances.Queries.Dto;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.AttendanceMapping
{
    public partial class AttendanceProfile
    {
        public void AttendanceQueryMapping()
        {
            CreateMap<Attendance, AttendanceDto>();
        }
    }
}
