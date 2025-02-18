using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Models
{
    public class DeleteAttendanceCommand : IRequest<Response<string>>
    {
        public int AttendanceID { get; set; }
    }
}
