using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Mapping.AppUserMapping
{
    public partial class AppUserMappingProfile
    {
        public void AppUserRegisteration()
        {
            CreateMap<RegisterCommand, AppUser>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
