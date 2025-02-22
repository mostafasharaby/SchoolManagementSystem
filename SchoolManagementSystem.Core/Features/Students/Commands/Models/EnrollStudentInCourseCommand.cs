using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class EnrollStudentInCourseCommand : IRequest<Response<string>>
    {
        public string StudentID { get; set; }
        public int CourseID { get; set; }
    }
}
