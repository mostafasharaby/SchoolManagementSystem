using MediatR;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class DeleteTeacherCommand : IRequest<bool>
    {
        public int TeacherID { get; }

        public DeleteTeacherCommand(int teacherID)
        {
            TeacherID = teacherID;
        }
    }
}
