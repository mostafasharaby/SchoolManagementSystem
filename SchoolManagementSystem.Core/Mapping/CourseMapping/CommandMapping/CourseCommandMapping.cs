using SchoolManagementSystem.Core.Features.Courses.Commands.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {
        public void CourseCommandMapping()
        {
            CreateMap<CourseDto, Course>();
            CreateMap<UpdateCourseCommand, Course>();
        }
    }
}
