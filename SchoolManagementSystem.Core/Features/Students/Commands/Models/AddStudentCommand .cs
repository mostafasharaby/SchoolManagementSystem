using MediatR;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Student>
    {
        public Student Student { get; }
        public AddStudentCommand(Student student)
        {
            Student = student;

        }
    }
}
