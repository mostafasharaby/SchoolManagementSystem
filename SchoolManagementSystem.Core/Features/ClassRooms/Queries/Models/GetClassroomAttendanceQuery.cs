using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models
{
    public class GetClassroomAttendanceQuery : IRequest<Response<List<AttendanceDto>>>
    {
        public int ClassroomId;
    }
}
