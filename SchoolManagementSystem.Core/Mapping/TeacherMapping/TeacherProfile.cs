using AutoMapper;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Results;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Mapping.TeacherMapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {           
                CreateMap<Teacher, TeacherDto>();
        }
    }
}
