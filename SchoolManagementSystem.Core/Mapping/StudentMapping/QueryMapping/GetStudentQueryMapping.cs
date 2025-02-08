using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.General;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void getStudentDtoQueryMapping()
        {
            CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.StudentFirstName, opt => opt.MapFrom(new LocalizedResolver<Student>(
                s => s.StudentFirstNameAr,
                s => s.StudentFirstNameEn)))
            .ForMember(dest => dest.StudentLastName, opt => opt.MapFrom(new LocalizedResolver<Student>(
                s => s.StudentLastNameAr,
                s => s.StudentLastNameEn)))
            .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.ClassroomName))
             .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Classroom.Teacher.TeacherFirstName));
        }


    }
}
