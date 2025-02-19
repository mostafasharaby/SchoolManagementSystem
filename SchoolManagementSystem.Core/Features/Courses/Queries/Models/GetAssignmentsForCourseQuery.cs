using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Models
{
    public class GetAssignmentsForCourseQuery : IRequest<Response<List<AssignmentDto>>>
    {
        public int CourseID { get; set; }
    }
}
