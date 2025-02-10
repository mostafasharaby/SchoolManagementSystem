using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Results;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models
{
    public class UpdateAppUserCommand : IRequest<Response<AppUserDto>> // for admin 
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class UpdateProfileCommand : IRequest<Response<string>> // for user
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class UpdateProfileRequest : IRequest<Response<string>>
    {
        public string UserId { get; }
        public UpdateProfileCommand Command { get; }

        public UpdateProfileRequest(string userId, UpdateProfileCommand command)
        {
            UserId = userId;
            Command = command;
        }
    }
}
