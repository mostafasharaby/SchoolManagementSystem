using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Courses.Commands.Models
{
    public class DeleteCourseCommand : IRequest<Response<string>>
    {
        public int CourseID { get; set; }
    }
}
