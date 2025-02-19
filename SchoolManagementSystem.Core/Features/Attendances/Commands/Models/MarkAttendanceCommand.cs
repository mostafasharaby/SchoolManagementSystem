using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Models
{
    public class MarkAttendanceCommand : IRequest<Response<string>>
    {
        public int ClassroomID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public List<StudentAttendanceDto>? StudentAttendances { get; set; }
    }

}
