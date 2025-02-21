using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentAttendanceQuery : IRequest<Response<List<AttendanceDto>>>
    {
        public int StudentID { get; set; }
    }
}
