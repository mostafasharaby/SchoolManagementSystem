using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<AddStudentCommand, Student>();

            CreateMap<AddStudentCommandWithResponse, Student>()
                .ForMember(des => des.ClassroomID, op => op.MapFrom(src => src.ClassroomIDDD))
                .ForMember(des => des.ParentID, op => op.MapFrom(src => src.ParentIDDD));

        }
    }
}
