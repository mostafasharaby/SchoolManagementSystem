using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Claims.Commands.Models
{
    public class UpdateUserClaimsCommand : IRequest<Response<string>>
    {
        public string? UserId { get; set; }
        public ClaimDetails? Claim { get; set; }
    }
}
