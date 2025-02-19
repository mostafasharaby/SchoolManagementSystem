using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Attendances.Queries.Models
{
    public class GetAttendanceSummaryQuery : IRequest<Response<AttendanceSummaryDto>>
    {
        public int ClassroomID { get; set; }
    }
}
