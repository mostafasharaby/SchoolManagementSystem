using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.CourseMapping
{
    public partial class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CourseCommandMapping();
            CourseQueryMapping();
        }
    }
}
