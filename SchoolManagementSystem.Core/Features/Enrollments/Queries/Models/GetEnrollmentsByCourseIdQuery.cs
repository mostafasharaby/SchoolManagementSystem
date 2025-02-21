using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Enrollments.Queries.Models
{
    public class GetEnrollmentsByCourseIdQuery : IRequest<Response<List<EnrollmentDto>>>
    {
        public int CourseID { get; set; }
    }
}
