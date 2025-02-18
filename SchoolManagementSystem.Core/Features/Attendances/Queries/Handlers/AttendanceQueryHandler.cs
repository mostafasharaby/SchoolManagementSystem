using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Attendances.Queries.Dto;
using SchoolManagementSystem.Core.Features.Attendances.Queries.Models;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Attendances.Queries.Handlers
{
    internal class AttendanceQueryHandler : IRequestHandler<GetAttendanceByIdQuery, Response<AttendanceDto>>,
                                            IRequestHandler<GetAllAttendancesQuery, Response<List<AttendanceDto>>>
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public AttendanceQueryHandler(IMapper mapper, ResponseHandler responseHandler, IAttendanceService attendanceService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _attendanceService = attendanceService;
        }
        public async Task<Response<AttendanceDto>> Handle(GetAttendanceByIdQuery request, CancellationToken cancellationToken)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(request.AttendanceID);
            if (attendance == null)
                return _responseHandler.NotFound<AttendanceDto>("Attendance record not found.");

            var dto = _mapper.Map<AttendanceDto>(attendance);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<AttendanceDto>>> Handle(GetAllAttendancesQuery request, CancellationToken cancellationToken)
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            var dtoList = _mapper.Map<List<AttendanceDto>>(attendances);
            return _responseHandler.Success(dtoList);
        }
    }
}
