using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Attendances.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Models
{
    public class AddAttendanceCommand : AttendanceDto, IRequest<Response<string>>
    {
    }
}
