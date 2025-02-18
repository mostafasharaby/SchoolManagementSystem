using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Models
{
    public class GetCourseByIdQuery : IRequest<Response<CourseDto>>
    {
        public int CourseID { get; set; }
    }
}
