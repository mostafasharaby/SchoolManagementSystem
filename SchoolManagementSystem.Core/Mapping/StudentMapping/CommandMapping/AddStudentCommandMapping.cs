using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentProfile()
        {
            CreateMap<AddStudentCommandWithResponse, Student>()
                .ForMember(des => des.ClassroomID, op => op.MapFrom(src => src.ClassroomIDDD))
                .ForMember(des => des.ParentID, op => op.MapFrom(src => src.ParentIDDD));
        }
    }
}
