using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.EnrollmentMapping
{
    public partial class EnrollmentProfile
    {
        public void EnrollmentQueryMapping()
        {
            CreateMap<Enrollment, EnrollmentDto>();
        }
    }
}
