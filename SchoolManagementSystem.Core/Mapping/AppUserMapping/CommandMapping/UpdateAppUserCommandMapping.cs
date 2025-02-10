using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Mapping.AppUserMapping
{
    public partial class AppUserMappingProfile
    {
        public void UpdateAppUserMapping()
        {
            CreateMap<UpdateAppUserCommand, AppUser>()
                 .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProfileCommand, AppUser>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
