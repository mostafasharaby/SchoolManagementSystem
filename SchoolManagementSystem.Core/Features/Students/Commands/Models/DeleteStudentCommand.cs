using MediatR;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int StudentID { get; }

        public DeleteStudentCommand(int studentID)
        {
            StudentID = studentID;
        }
    }
}
