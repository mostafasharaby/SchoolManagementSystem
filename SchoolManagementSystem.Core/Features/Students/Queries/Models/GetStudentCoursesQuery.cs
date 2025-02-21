using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentCoursesQuery : IRequest<Response<List<CourseDto>>>
    {
        public int StudentID { get; set; }
    }
}
