using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Views;


namespace SchoolManagementSystem.Core.Features.Claims.Queries.Models
{
    public class UserRoleClaimQuery : IRequest<Response<List<UserRolesClaimsView>>>
    {
        public string? UserId { get; set; }
    }
}
