using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Mapping.AuthMapping
{
    public partial class AuthProfile
    {
        public void UserLogin()
        {
            CreateMap<LoginCommand, AppUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
