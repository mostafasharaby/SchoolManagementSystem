using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Attendances.Queries.Models
{
    public class GetAllAttendancesQuery : IRequest<Response<List<AttendanceDto>>> { }

}
