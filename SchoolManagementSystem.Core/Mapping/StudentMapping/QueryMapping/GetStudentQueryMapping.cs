using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void getStudentDtoQueryMapping()
        {
            CreateMap<Student, StudentDto>()
               .ForMember(dest => dest.ParentFirstName, opt => opt.MapFrom(src => src.Parent.FirstName))
               .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.ClassroomName))
               .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Classroom.Teacher.TeacherFirstName));
        }
           
       
    }
}
