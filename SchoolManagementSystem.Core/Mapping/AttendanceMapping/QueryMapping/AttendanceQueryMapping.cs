using SchoolManagementSystem.Data.DTO;
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
