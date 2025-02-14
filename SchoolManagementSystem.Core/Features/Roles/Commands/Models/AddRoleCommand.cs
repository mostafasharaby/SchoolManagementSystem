using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Models
{
    public record AddRoleCommand(string RoleName) : IRequest<Response<string>>
    { }
}

