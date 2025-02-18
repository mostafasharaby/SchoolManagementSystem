using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {
        public void CourseQueryMapping()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
