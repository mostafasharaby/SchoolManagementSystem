using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class GoogleLoginCommand : IRequest<AuthenticationProperties>
    {
        public string? RedirectUri { get; set; }
    }
}
