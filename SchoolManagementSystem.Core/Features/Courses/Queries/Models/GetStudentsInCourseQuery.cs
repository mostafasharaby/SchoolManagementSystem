using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Models
{
    public class GetStudentsInCourseQuery : IRequest<Response<List<StudentDto>>>
    {
        public int CourseID { get; set; }
    }
}
