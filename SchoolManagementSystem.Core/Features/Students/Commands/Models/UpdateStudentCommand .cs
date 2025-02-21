using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommand : StudentDto, IRequest<Response<string>>
    {
        public int StudentID { get; set; }
        //public Student Student { get; }
        //public int StudentID { get; }
        //public UpdateStudentCommand(Student student)
        //{
        //    Student = student;
        //    StudentID = student.StudentID;
        //}
    }
}
