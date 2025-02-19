using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void TeacherCommandMapping()
        {
            CreateMap<TeacherDto, Teacher>();
            CreateMap<UpdateTeacherCommand, Teacher>();
        }
    }
}
