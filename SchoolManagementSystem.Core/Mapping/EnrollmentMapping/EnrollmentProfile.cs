using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.EnrollmentMapping
{
    public partial class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            EnrollmentCommandMapping();
            EnrollmentQueryMapping();
        }
    }
}
