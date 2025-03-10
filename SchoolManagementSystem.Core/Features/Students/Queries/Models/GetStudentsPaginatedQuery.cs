﻿using MediatR;
using SchoolManagementSystem.Core.Wrapper;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Helpers;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedQuery : IRequest<PaginatedResult<StudentDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }


}
