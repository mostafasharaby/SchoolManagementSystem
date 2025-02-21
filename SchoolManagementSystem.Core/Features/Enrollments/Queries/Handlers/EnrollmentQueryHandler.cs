using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Enrollments.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Enrollments.Queries.Handlers
{
    public class EnrollmentQueryHandler : IRequestHandler<GetEnrollmentByIdQuery, Response<EnrollmentDto>>,
                                          IRequestHandler<GetAllEnrollmentsQuery, Response<List<EnrollmentDto>>>,
                                          IRequestHandler<GetEnrollmentsByCourseIdQuery, Response<List<EnrollmentDto>>>

    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public EnrollmentQueryHandler(IEnrollmentService enrollmentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<Response<EnrollmentDto>> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(request.EnrollmentID);
            if (enrollment == null)
                return _responseHandler.NotFound<EnrollmentDto>("Enrollment not found.");

            var dto = _mapper.Map<EnrollmentDto>(enrollment);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<EnrollmentDto>>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            var dtoList = _mapper.Map<List<EnrollmentDto>>(enrollments);
            return _responseHandler.Success(dtoList);
        }
        public async Task<Response<List<EnrollmentDto>>> Handle(GetEnrollmentsByCourseIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var enrollments = await _enrollmentService.GetEnrollmentsByCourseIdAsync(request.CourseID);
                var dtoList = _mapper.Map<List<EnrollmentDto>>(enrollments);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<EnrollmentDto>>(ex.Message);
            }

        }

    }

}
