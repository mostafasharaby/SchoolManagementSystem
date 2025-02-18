using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Commands.Models
{
    public class UpdateCourseCommand : CourseDto, IRequest<Response<string>>
    {
        public int CourseID { get; set; }
    }
}
