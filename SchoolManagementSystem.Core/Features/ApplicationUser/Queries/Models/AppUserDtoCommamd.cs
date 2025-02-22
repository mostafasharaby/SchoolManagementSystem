using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Models
{
    public class AppUserDtoCommamd : IRequest<Response<AppUserDto>>
    {
        public string UserId { get; set; }  // Added UserId property

        public AppUserDtoCommamd(string userId)
        {
            UserId = userId;
        }
    }
}
