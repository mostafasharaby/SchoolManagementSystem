using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    public class GetStudentDtoQueryWithStatusHandler : IRequestHandler<GetStudentDtoQueryWithStatus, Response<List<StudentDto>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        public GetStudentDtoQueryWithStatusHandler(IStudentService studentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _studentService = studentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<Response<List<StudentDto>>> Handle(GetStudentDtoQueryWithStatus request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentAsync();
            return _responseHandler.Success(_mapper.Map<List<StudentDto>>(studentList));
        }


    }
}
