using AutoMapper;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Results;
using SchoolManagementSystem.Data.Entities;

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
