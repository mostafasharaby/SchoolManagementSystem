using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Commands.Models
{
    public class AddCourseCommand : CourseDto, IRequest<Response<string>>
    {
    }
}
