using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Models
{
    public class AddAttendanceCommand : AttendanceDto, IRequest<Response<string>>
    {
    }
}
