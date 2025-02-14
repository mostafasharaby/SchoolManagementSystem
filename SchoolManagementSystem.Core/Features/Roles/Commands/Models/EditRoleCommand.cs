using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Models
{
    public record EditRoleCommand(string RoleId, string NewRoleName) : IRequest<Response<string>>;

}
