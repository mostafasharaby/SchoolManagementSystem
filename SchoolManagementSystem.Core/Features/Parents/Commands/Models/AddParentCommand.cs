using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Models
{
    public class AddParentCommand : ParentDto, IRequest<Response<string>>
    {
    }
}
