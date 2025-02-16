using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Roles.Queries.Models
{
    public class GetUserCountByRoleQuery : IRequest<Response<int>>
    {
        public string RoleName { get; set; }
        public GetUserCountByRoleQuery(string roleName)
        {
            RoleName = roleName;
        }
    }
}
