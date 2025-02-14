using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Claims.Queries.Models
{
    public class GetUserClaimsByIdQuery : IRequest<Response<UserClaims>>
    {
        public string? UserId { get; set; }
    }
}
