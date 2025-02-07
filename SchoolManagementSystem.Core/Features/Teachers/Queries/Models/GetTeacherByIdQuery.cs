using MediatR;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public int TeacherID { get; }

        public GetTeacherByIdQuery(int studentID)
        {
            TeacherID = studentID;
        }
    }
}
