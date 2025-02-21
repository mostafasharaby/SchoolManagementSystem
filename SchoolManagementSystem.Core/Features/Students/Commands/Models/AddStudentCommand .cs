using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : StudentDto, IRequest<Response<string>>
    {
    }
}
