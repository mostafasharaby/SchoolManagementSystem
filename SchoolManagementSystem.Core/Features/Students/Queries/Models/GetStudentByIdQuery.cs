using MediatR;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int StudentID { get; }

        public GetStudentByIdQuery(int studentID)
        {
            StudentID = studentID;
        }
    }
}
