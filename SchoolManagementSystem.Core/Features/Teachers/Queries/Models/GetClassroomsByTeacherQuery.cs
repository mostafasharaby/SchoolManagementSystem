using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetClassroomsByTeacherQuery : IRequest<Response<List<ClassroomDto>>>
    {
        public int TeacherID { get; set; }
    }

}
