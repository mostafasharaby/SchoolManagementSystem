using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    public class GetStudentDtoQueryWithStatusHandler : ResponseHandler, IRequestHandler<GetStudentDtoQueryWithStatus, Response<List<StudentDto>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public GetStudentDtoQueryWithStatusHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<List<StudentDto>>> Handle(GetStudentDtoQueryWithStatus request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentAsync();
            return Success(_mapper.Map<List<StudentDto>>(studentList));
        }

      
    }
}
