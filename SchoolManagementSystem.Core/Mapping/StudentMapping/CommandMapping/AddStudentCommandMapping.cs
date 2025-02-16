using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentProfile()
        {
            //CreateMap<AddStudentCommandWithResponse, Student>()
            //    .ForMember(dest => dest.GetCultureLanguage(dest.StudentFirstNameAr, dest.StudentFirstNameEn), opt => opt.MapFrom(src => src.StudentFirstName))
            //    .ForMember(dest => dest.GetCultureLanguage(dest.StudentLastNameAr, dest.StudentLastNameEn), opt => opt.MapFrom(src => src.StudentLastName))
            //    .ForMember(des => des.ClassroomID, op => op.MapFrom(src => src.ClassroomIDDD))
            //    .ForMember(des => des.ParentID, op => op.MapFrom(src => src.ParentIDDD));

            CreateMap<AddStudentCommandWithResponse, Student>()
                .ForMember(dest => dest.StudentFirstNameAr, opt => opt.MapFrom(opt => opt.StudentFirstNameAr))
                .ForMember(dest => dest.StudentFirstNameEn, opt => opt.MapFrom(opt => opt.StudentFirstNameEn))
                .ForMember(dest => dest.StudentLastNameAr, opt => opt.MapFrom(opt => opt.StudentLastNameAr))
                .ForMember(dest => dest.StudentLastNameEn, opt => opt.MapFrom(opt => opt.StudentLastNameEn))
                .ForMember(des => des.ClassroomID, op => op.MapFrom(src => src.ClassroomIDDD))
                .ForMember(des => des.ParentID, op => op.MapFrom(src => src.ParentIDDD))
                .ForMember(des => des.StudentGender, op => op.MapFrom(src => src.StudentGender))
                .ForMember(des => des.StudentAddress, op => op.MapFrom(src => src.StudentAddress));

        }
    }
}
