using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Models
{
    public class GetCoursesByDepartmentQuery : IRequest<Response<List<CourseDto>>>
    {
        public int DepartmentID { get; set; }
    }
}
