using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<AuthResponse>>
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
