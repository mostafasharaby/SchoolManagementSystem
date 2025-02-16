using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;
namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class AddStudentCommandWithResponseHandler : IRequestHandler<AddStudentCommandWithResponse, Response<Student>>
    {

        private readonly IStudentService _studentService;
        public readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;

        public AddStudentCommandWithResponseHandler(IStudentService studentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _studentService = studentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<Response<Student>> Handle(AddStudentCommandWithResponse request, CancellationToken cancellationToken)
        {
            var studentMapped = _mapper.Map<Student>(request);

            if (studentMapped == null)
            {
                return new Response<Student>("Mapping failed");
            }

            //var result = await _studentService.AddStudentAsync(studentMapped);
            var result = await _studentService.AddStudentWithImageAsync(studentMapped, request.Image);
            if (result == null)
            {
                return new Response<Student>("this student is exist");
            }
            return _responseHandler.Created(result);
        }


    }
}
