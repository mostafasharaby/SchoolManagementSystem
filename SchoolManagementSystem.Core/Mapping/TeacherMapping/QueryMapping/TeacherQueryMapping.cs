using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void TeacherQueryMapping()
        {
            CreateMap<Teacher, TeacherDto>();
        }
    }
}
