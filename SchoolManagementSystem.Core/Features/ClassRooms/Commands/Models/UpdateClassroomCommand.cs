using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models
{
    public class UpdateClassroomCommand : IRequest<Response<string>>
    {
        public int ClassroomID { get; set; }
        public string? ClassroomName { get; set; }
        public int? GradeID { get; set; }
        public int? TeacherID { get; set; }
    }
}
