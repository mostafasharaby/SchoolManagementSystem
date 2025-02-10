using MediatR;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class GoogleLoginCallbackCommand : IRequest<string>
    {
    }
}
