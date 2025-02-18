using SchoolManagementSystem.Core.Features.Enrollments.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.EnrollmentMapping
{
    public partial class EnrollmentProfile
    {
        public void EnrollmentCommandMapping()
        {
            CreateMap<AddEnrollmentCommand, Enrollment>();
            CreateMap<UpdateEnrollmentCommand, Enrollment>();
        }
    }
}
