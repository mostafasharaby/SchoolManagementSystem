using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class StudentByIdResponseQuery : IRequest<StudentByIdResponse>
    {
        public int StudentID { get; }

        public StudentByIdResponseQuery(int studentID)
        {
            StudentID = studentID;
        }
    }
}
