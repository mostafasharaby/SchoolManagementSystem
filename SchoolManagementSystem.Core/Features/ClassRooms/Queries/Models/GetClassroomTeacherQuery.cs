using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models
{
    public class GetClassroomTeacherQuery : IRequest<Response<TeacherDto>>
    {
        public int ClassroomId;
    }
}
