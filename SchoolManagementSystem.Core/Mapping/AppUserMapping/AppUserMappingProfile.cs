using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.AppUserMapping
{
    public partial class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            AppUserRegisteration();
            GetAppUserDetails();
            UpdateAppUserMapping();
        }
    }
}
