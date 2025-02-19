using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class AddTeacherCommand : TeacherDto, IRequest<Response<string>>
    {
    }
}
