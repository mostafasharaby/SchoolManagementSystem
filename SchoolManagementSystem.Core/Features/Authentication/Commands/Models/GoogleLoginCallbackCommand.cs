using MediatR;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class GoogleLoginCallbackCommand : IRequest<AuthResponse>
    {
    }
}
