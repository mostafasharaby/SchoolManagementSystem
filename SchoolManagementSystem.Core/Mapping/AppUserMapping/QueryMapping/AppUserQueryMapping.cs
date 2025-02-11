using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Results;
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
