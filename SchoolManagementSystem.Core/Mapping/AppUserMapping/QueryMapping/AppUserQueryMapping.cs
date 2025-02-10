using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Mapping.AppUserMapping
{
    public partial class AppUserMappingProfile
    {
        public void GetAppUserDetails()
        {
            CreateMap<AppUser, AppUserDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
