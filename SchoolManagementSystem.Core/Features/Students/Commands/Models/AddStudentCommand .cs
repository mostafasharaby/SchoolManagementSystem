using MediatR;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand:IRequest<Student>
    {
        public Student Student { get; }
        public AddStudentCommand(Student student)
        {
            Student = student;
        }
    }
}
