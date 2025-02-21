using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<UpdateStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public StudentCommandHandler(IMapper mapper, ResponseHandler responseHandler, IStudentService studentService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _studentService = studentService;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = _mapper.Map<Student>(request);
                await _studentService.AddStudentAsync(student);
                return _responseHandler.Created("Student created successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = _mapper.Map<Student>(request);
                await _studentService.UpdateStudentAsync(student);
                return _responseHandler.Success("Student updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest<string>("An unexpected error occurred: " + ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.DeleteStudentAsync(request.StudentID);
            if (!result)
                return _responseHandler.NotFound<string>("Student not found.");

            return _responseHandler.Success("Student deleted successfully.");
        }
    }

}
