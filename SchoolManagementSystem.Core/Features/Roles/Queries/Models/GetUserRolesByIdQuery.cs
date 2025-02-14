using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Roles.Queries.Models
{
    public class GetUserRolesByIdQuery : IRequest<Response<UserRoles>>
    {
        public string? UserId { get; set; }
    }
}
