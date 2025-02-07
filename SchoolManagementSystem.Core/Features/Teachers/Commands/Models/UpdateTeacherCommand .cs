using MediatR;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class UpdateTeacherCommand : IRequest<Teacher>
    {
        public Teacher Teacher { get; }
        public int TeacherID { get; }
        public UpdateTeacherCommand(Teacher teacher)
        {
            Teacher = teacher;
            TeacherID = teacher.TeacherID;
        }
    }
}
