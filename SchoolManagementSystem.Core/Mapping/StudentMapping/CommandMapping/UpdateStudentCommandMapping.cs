using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    partial class StudentProfile
    {
        public void UpdateStudentProfile()
        {
            CreateMap<UpdateStudentCommandWithValidation, Student>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentID))
            .ForMember(dest => dest.StudentFirstNameEn, opt => opt.MapFrom(src => src.StudentFirstNameEn))
            .ForMember(dest => dest.StudentLastNameEn, opt => opt.MapFrom(src => src.StudentLastNameEn))
            .ForMember(dest => dest.StudentFirstNameAr, opt => opt.MapFrom(src => src.StudentFirstNameAr))
            .ForMember(dest => dest.StudentLastNameAr, opt => opt.MapFrom(src => src.StudentLastNameAr))
            .ForMember(dest => dest.StudentGender, opt => opt.MapFrom(src => src.StudentGender))
            .ForMember(dest => dest.StudentAddress, opt => opt.MapFrom(src => src.StudentAddress))
            .ForMember(dest => dest.ParentID, opt => opt.MapFrom(src => src.ParentIDDD))
            .ForMember(dest => dest.ClassroomID, opt => opt.MapFrom(src => src.ClassroomIDDD));
        }
    }
}

