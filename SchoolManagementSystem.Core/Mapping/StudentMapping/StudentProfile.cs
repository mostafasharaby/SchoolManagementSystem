using AutoMapper;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.ClassroomName))
                .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Classroom.Teacher.TeacherFirstName));
        }
    }
}
