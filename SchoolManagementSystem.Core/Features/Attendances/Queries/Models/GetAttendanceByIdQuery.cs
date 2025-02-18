using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Attendances.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.Attendances.Queries.Models
{
    public class GetAttendanceByIdQuery : IRequest<Response<AttendanceDto>>
    {
        public int AttendanceID { get; set; }
    }
}
