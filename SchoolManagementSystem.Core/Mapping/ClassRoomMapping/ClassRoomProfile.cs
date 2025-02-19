using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.ClassRoomMapping
{
    public partial class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
            AddClassRoomCommandMapping();
            UpdateClassRoomCommandMapping();
            AddClassroomWithStudentsCommandMapping();
            ClassRoomQueryMapping();
        }
    }
}
