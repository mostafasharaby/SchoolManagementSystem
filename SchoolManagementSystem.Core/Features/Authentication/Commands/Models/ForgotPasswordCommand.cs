using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class ForgotPasswordCommand : IRequest<Response<string>>
    {
        public string? Email { get; set; }
    }

}
