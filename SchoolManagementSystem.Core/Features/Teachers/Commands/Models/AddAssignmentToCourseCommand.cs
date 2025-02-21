using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class AddAssignmentToCourseCommand : IRequest<Response<string>>
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public string AssignmentName { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}
