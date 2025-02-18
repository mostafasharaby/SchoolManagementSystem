using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Assignments.Commands.Models
{
    public class UpdateAssignmentCommand : AssignmentDto, IRequest<Response<string>>
    {
        public int AssignmentID { get; set; }
    }
}
