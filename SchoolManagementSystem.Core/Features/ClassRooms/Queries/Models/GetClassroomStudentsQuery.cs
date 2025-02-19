using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models
{
    public class GetClassroomStudentsQuery : IRequest<Response<List<StudentDto>>>
    {
        public int ClassroomId;
    }
}
