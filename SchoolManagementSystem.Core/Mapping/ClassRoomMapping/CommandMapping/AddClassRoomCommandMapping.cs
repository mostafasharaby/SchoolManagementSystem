using SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ClassRoomMapping
{
    public partial class ClassRoomProfile
    {
        public void AddClassRoomCommandMapping()
        {
            CreateMap<AddClassroomCommand, Classroom>();
        }
        public void AddClassroomWithStudentsCommandMapping()
        {
            CreateMap<AddClassroomWithStudentsCommand, Classroom>();
        }

    }
}
