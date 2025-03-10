﻿using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommand : StudentDto, IRequest<Response<string>>
    {
        public string StudentID { get; set; }
    }
}
