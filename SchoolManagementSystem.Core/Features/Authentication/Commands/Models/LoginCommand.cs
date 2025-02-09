using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class LoginCommand : IRequest<Response<AuthResponse>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
