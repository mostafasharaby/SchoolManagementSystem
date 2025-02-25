﻿using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.General;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void getStudentDtoQueryMapping()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, GetStudentsPaginatedQuery>();

            CreateMap<Student, Student_Teacher_ClassRomm_Parent_Dto>()
            .ForMember(dest => dest.StudentFirstName, opt => opt.MapFrom(new LocalizedResolver<Student>(
                s => s.StudentFirstNameAr,
                s => s.StudentFirstNameEn)))
            .ForMember(dest => dest.StudentLastName, opt => opt.MapFrom(new LocalizedResolver<Student>(
                s => s.StudentLastNameAr,
                s => s.StudentLastNameEn)))
            .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom!.ClassroomName))
             .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Classroom.Teacher.TeacherFirstName));
        }


    }
}
