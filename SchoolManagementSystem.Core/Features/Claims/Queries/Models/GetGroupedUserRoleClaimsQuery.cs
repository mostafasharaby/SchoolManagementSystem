using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Views;

namespace SchoolManagementSystem.Core.Features.Claims.Queries.Models
{
    public class GetGroupedUserRoleClaimsQuery : IRequest<Response<List<UserRoleClaimGroupedDto>>> { }

}
