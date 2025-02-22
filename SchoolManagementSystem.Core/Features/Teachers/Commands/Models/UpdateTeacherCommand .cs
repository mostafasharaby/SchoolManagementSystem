using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class UpdateTeacherCommand : TeacherDto, IRequest<Response<string>>
    {
        public string? TeacherID { get; set; }
    }
}
