using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Models
{
    public class GetAllCoursesQuery : IRequest<Response<List<CourseDto>>> { }

}
