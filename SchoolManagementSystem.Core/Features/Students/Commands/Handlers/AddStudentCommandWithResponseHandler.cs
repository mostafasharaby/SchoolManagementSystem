using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using AutoMapper;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Services.Abstracts;
using SchoolManagementSystem.Core.Bases;
namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class AddStudentCommandWithResponseHandler : IRequestHandler<AddStudentCommandWithResponse, Response<Student>>
    {
        
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public AddStudentCommandWithResponseHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<Student>> Handle(AddStudentCommandWithResponse request, CancellationToken cancellationToken)
        {
            var studentMapped = _mapper.Map<Student>(request); 

            if (studentMapped == null)
            {
                return new Response<Student>("Mapping failed");
            }

            var result = await _studentService.AddStudentAsync(studentMapped);
            if(result == null)
            {
                return new Response<Student>("this student is exist");
            }
            var responseHandler = new ResponseHandler();
            return responseHandler.Created(result);
        }


    }
}
