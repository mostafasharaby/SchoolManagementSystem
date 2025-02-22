using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetStudentsInClassroomQuery : IRequest<Response<List<StudentDto>>>
    {
        public string? TeacherID { get; set; }
        public int ClassroomID { get; set; }
    }
}
