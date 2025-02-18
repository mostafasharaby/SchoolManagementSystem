using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Enrollments.Commands.Models
{
    public class DeleteEnrollmentCommand : IRequest<Response<string>>
    {
        public int EnrollmentID { get; set; }
    }

}
