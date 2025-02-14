using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Models
{
    public class UpdateUserRoleCommand : IRequest<Response<string>>
    {
        public string? UserId { get; set; }
        public string? RoleName { get; set; }
        public string? OldRoleName { get; set; }

    }
}
