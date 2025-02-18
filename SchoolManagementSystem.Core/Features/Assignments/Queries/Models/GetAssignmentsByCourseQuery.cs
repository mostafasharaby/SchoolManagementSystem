using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Assignments.Queries.Models
{
    public class GetAssignmentsByCourseQuery : IRequest<Response<List<AssignmentDto>>>
    {
        public int CourseID { get; set; }
    }
}
