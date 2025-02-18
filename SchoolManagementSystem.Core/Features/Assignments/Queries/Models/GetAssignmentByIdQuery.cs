using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Assignments.Queries.Models
{
    public class GetAssignmentByIdQuery : IRequest<Response<AssignmentDto>>
    {
        public int AssignmentID { get; set; }
    }

}
