using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.AuthMapping
{
    public partial class AuthProfile : Profile
    {
        public AuthProfile()
        {
            UserLogin();
        }
    }
}
