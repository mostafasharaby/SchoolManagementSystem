using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ClassRoomMapping
{
    public partial class ClassRoomProfile
    {
        public void ClassRoomQueryMapping()
        {
            CreateMap<Classroom, ClassroomDto>();
        }
    }
}
