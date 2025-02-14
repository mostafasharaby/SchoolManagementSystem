using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Roles.Queries.Models
{
    public record GetRolesQuery() : IRequest<Response<List<RoleResponse>>>;
}
