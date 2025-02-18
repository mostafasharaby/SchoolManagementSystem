using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Assignments.Commands.Models
{
    public class DeleteAssignmentCommand : IRequest<Response<string>>
    {
        public int AssignmentID { get; set; }
    }
}
