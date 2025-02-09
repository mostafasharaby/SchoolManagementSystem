using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models
{
    public class RegisterCommand : IRequest<Response<string>>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Email { get; set; }
    }
}
