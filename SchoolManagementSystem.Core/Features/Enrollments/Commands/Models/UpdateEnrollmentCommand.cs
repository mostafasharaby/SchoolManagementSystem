using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Enrollments.Commands.Models
{
    public class UpdateEnrollmentCommand : EnrollmentDto, IRequest<Response<string>>
    {
        public int EnrollmentID { get; set; }
    }
}
