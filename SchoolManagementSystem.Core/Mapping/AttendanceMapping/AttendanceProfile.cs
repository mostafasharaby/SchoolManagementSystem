using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.AttendanceMapping
{
    public partial class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            AttendanceCommandMapping();
            AttendanceQueryMapping();
        }
    }
}
