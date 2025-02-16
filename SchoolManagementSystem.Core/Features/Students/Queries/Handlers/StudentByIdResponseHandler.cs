using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Services.Abstracts;
using Serilog;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    internal class StudentByIdResponseHandler : IRequestHandler<StudentByIdResponseQuery, StudentByIdResponse>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        public StudentByIdResponseHandler(IStudentService studentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _studentService = studentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<StudentByIdResponse> Handle(StudentByIdResponseQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentAsyncByIDResponse(request.StudentID);
            if (student == null)
            {
                _responseHandler.NotFound<StudentByIdResponse>();
                return null;
            }
            Log.Information("User {UserName} performed an action at {Time}", request.StudentID, DateTime.UtcNow);

            return _mapper.Map<StudentByIdResponse>(student);
        }
    }
}
