using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Mapping.AppUserMapping
{
    public partial class AppUserMappingProfile
    {
        public void AppUserRegisteration()
        {
            CreateMap<RegisterAdminCommand, AppUser>();
            CreateMap<RegisterTeacherCommand, Teacher>();
            CreateMap<RegisterStudentCommand, Student>();

            // CreateMap<RegisterCommand, Student>()
            //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //     ;
            // //              .ForMember(i=>i.PhoneNumber,c=>c.MapFrom(i=>i.pa;
            // CreateMap<RegisterCommand, Teacher>();

        }
    }
}
