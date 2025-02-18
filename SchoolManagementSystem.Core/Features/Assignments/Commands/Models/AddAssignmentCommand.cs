using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Assignments.Commands.Models
{
    public class AddAssignmentCommand : AssignmentDto, IRequest<Response<string>> { }

}
