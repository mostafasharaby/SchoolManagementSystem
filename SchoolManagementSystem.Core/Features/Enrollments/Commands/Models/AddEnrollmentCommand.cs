using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Enrollments.Commands.Models
{
    public class AddEnrollmentCommand : EnrollmentDto, IRequest<Response<string>>
    {
    }
}
