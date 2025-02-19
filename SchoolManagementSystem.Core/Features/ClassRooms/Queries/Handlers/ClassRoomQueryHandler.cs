using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Handlers
{
    internal class ClassRoomQueryHandler : IRequestHandler<GetClassroomByIdQuery, Response<Classroom>>,
                                           IRequestHandler<GetAllClassroomsQuery, Response<List<Classroom>>>,
                                           IRequestHandler<GetClassroomStudentsQuery, Response<List<StudentDto>>>,
                                           IRequestHandler<GetClassroomAttendanceQuery, Response<List<AttendanceDto>>>,
                                           IRequestHandler<GetClassroomTeacherQuery, Response<TeacherDto>>
    {
        private readonly IClassRoomService _classRoomService;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;

        public ClassRoomQueryHandler(IClassRoomService classRoomService, ResponseHandler responseHandler, IMapper mapper)
        {
            _classRoomService = classRoomService;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        public async Task<Response<List<Classroom>>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
        {
            var classrooms = await _classRoomService.GetAllClassroomsAsync();
            return _responseHandler.Success(classrooms);
        }

        public async Task<Response<Classroom>> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
        {
            var classroom = await _classRoomService.GetClassroomByIdAsync(request.ClassroomID);
            if (classroom == null)
                return _responseHandler.NotFound<Classroom>("ClassroomId not found.");


            return _responseHandler.Success(classroom);
        }

        public async Task<Response<List<StudentDto>>> Handle(GetClassroomStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var students = await _classRoomService.GetStudentsInClassroomAsync(request.ClassroomId);
                var response = _mapper.Map<List<StudentDto>>(students);
                return _responseHandler.Success(response);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<StudentDto>>(ex.Message);
            }
        }

        public async Task<Response<List<AttendanceDto>>> Handle(GetClassroomAttendanceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var attendanceRecords = await _classRoomService.GetAttendanceRecordsAsync(request.ClassroomId);
                var response = _mapper.Map<List<AttendanceDto>>(attendanceRecords);
                return _responseHandler.Success(response);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<AttendanceDto>>(ex.Message);
            }
        }

        public async Task<Response<TeacherDto>> Handle(GetClassroomTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _classRoomService.GetTeacherInClassroomAsync(request.ClassroomId);
            //var filter =  teacher != null
            //   ? _responseHandler.Success(teacher)
            //   : _responseHandler.NotFound<Teacher>("Teacher not found.");
            if (teacher == null)
                return _responseHandler.NotFound<TeacherDto>("ClassroomId not found.");

            var response = _mapper.Map<TeacherDto>(teacher);
            return _responseHandler.Success(response);

        }

    }
}
