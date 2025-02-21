using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Enrollments.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Enrollments.Commands.Handlers
{
    internal class EnrollmentCommandHandler : IRequestHandler<AddEnrollmentCommand, Response<string>>,
                                               IRequestHandler<UpdateEnrollmentCommand, Response<string>>,
                                               IRequestHandler<DeleteEnrollmentCommand, Response<string>>
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public EnrollmentCommandHandler(IEnrollmentService enrollmentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(AddEnrollmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var enrollment = _mapper.Map<Enrollment>(request);
                await _enrollmentService.AddEnrollmentAsync(enrollment);
                return _responseHandler.Created("Enrollment created successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);

            }
        }

        public async Task<Response<string>> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var enrollment = _mapper.Map<Enrollment>(request);
                await _enrollmentService.UpdateEnrollmentAsync(enrollment);
                return _responseHandler.Success("Enrollment updated successfully.");
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

        public async Task<Response<string>> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _enrollmentService.DeleteEnrollmentAsync(request.EnrollmentID);
            if (!result)
                return _responseHandler.NotFound<string>("Enrollment not found.");

            return _responseHandler.Success("Enrollment deleted successfully.");
        }
    }
}
