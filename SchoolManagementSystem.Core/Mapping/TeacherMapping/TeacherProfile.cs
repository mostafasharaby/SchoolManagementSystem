using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            TeacherCommandMapping();
            TeacherQueryMapping();
        }
    }
}
