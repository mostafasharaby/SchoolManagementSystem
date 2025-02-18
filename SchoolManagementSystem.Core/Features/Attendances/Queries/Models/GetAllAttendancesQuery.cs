using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Attendances.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.Attendances.Queries.Models
{
    public class GetAllAttendancesQuery : IRequest<Response<List<AttendanceDto>>> { }

}
