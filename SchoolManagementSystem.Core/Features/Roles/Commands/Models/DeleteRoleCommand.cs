using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Models
{
    public record DeleteRoleCommand(string RoleId) : IRequest<Response<string>>;
}
