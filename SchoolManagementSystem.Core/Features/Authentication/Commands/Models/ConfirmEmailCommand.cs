using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Models
{
    public class ConfirmEmailCommand : IRequest<Response<AppUser>>
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public ConfirmEmailCommand(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }

}
