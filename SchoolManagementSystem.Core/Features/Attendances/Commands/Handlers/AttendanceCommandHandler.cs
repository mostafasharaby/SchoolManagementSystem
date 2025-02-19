using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Attendances.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Handlers
{
    internal class AttendanceCommandHandler : IRequestHandler<AddAttendanceCommand, Response<string>>,
                                              IRequestHandler<UpdateAttendanceCommand, Response<string>>,
                                              IRequestHandler<DeleteAttendanceCommand, Response<string>>,
                                              IRequestHandler<MarkAttendanceCommand, Response<string>>



    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public AttendanceCommandHandler(IMapper mapper, ResponseHandler responseHandler, IAttendanceService attendanceService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _attendanceService = attendanceService;
        }

        public async Task<Response<string>> Handle(AddAttendanceCommand request, CancellationToken cancellationToken)
        {
            var attendance = _mapper.Map<Attendance>(request);
            await _attendanceService.AddAttendanceAsync(attendance);
            return _responseHandler.Created("Attendance record created successfully.");
        }

        public async Task<Response<string>> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var attendance = _mapper.Map<Attendance>(request);
                await _attendanceService.UpdateAttendanceAsync(attendance);
                return _responseHandler.Success("Attendance record updated successfully.");
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

        public async Task<Response<string>> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var result = await _attendanceService.DeleteAttendanceAsync(request.AttendanceID);
            if (!result)
                return _responseHandler.NotFound<string>("Attendance record not found.");

            return _responseHandler.Success("Attendance record deleted successfully.");
        }

        public async Task<Response<string>> Handle(MarkAttendanceCommand request, CancellationToken cancellationToken)
        {
            await _attendanceService.MarkAttendanceAsync(request.ClassroomID, request.AttendanceDate, request.StudentAttendances);
            return _responseHandler.Success("Attendance marked successfully.");
        }


    }
}
