using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Assignments.Queries.Models
{
    public class GetAllAssignmentsQuery : IRequest<Response<List<AssignmentDto>>> { }

}
