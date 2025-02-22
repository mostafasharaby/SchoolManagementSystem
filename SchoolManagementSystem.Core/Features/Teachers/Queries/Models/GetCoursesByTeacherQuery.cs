using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetCoursesByTeacherQuery : IRequest<Response<List<CourseDto>>>
    {
        public string? TeacherID { get; set; }
    }
}
