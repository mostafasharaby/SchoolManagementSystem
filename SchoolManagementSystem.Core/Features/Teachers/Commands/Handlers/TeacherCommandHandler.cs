using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Handlers
{
    internal class TeacherCommandHandler : IRequestHandler<AddTeacherCommand, Response<string>>,
                                            IRequestHandler<UpdateTeacherCommand, Response<string>>,
                                            IRequestHandler<DeleteTeacherCommand, Response<string>>
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public TeacherCommandHandler(IMapper mapper, ResponseHandler responseHandler, ITeacherService teacherService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _teacherService = teacherService;
        }

        public async Task<Response<string>> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(request);
                await _teacherService.AddTeacherAsync(teacher);
                return _responseHandler.Created("Teacher created successfully");
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

        public async Task<Response<string>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(request);
                await _teacherService.UpdateTeacherAsync(teacher);
                return _responseHandler.Success("Teacher updated successfully.");
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

        public async Task<Response<string>> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = await _teacherService.DeleteTeacherAsync(request.TeacherID);
            if (!result)
                return _responseHandler.NotFound<string>("Teacher not found.");

            return _responseHandler.Success("Teacher deleted successfully.");
        }


    }
}
