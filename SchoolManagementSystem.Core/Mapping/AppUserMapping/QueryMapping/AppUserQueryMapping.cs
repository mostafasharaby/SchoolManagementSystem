using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Mapping.AppUserMapping
{
    public partial class AppUserMappingProfile
    {
        public void GetAppUserDetails()
        {
            CreateMap<AppUser, AppUserDto>();
        }
    }
}
