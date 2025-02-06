using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    partial class StudentProfile
    {
        public void UpdateStudentProfile()
        {
            CreateMap<UpdateStudentCommandWithValidation, Student>()
            .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentID))
            .ForMember(dest => dest.StudentFirstName, opt => opt.MapFrom(src => src.StudentFirstName))
            .ForMember(dest => dest.StudentLastName, opt => opt.MapFrom(src => src.StudentLastName))
            .ForMember(dest => dest.StudentGender, opt => opt.MapFrom(src => src.StudentGender))
            .ForMember(dest => dest.StudentAddress, opt => opt.MapFrom(src => src.StudentAddress))
            .ForMember(dest => dest.ParentID, opt => opt.MapFrom(src => src.ParentIDDD))
            .ForMember(dest => dest.ClassroomID, opt => opt.MapFrom(src => src.ClassroomIDDD));
        }
    }
}

