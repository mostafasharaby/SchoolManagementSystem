using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.General;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void StudentByIdResponseMapping()
        {
            CreateMap<Student, StudentByIdResponse>()
            .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentFirstName, opt => opt.MapFrom(new LocalizedResolver<Student>(
                s => s.StudentFirstNameAr,
                s => s.StudentFirstNameEn)))
            .ForMember(dest => dest.StudentLastName, opt => opt.MapFrom(new LocalizedResolver<Student>(
                s => s.StudentLastNameAr,
                s => s.StudentLastNameEn)));
            //.ForMember(dest => dest.ParentResponse, opt => opt.MapFrom(src => src.Parent)) // ✅ Correct mapping
            //.ForMember(dest => dest.ClassroomResponse, opt => opt.MapFrom(src => src.Classroom));


            // CreateMap<Parent, ParentResponse>()
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ParentID));

            // CreateMap<Classroom, ClassroomResponse>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClassroomName))
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClassroomID));
        }


    }
}