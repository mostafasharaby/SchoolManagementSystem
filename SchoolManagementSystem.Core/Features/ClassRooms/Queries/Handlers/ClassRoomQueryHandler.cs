using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Handlers
{
    internal class ClassRoomQueryHandler : IRequestHandler<GetClassroomByIdQuery, Response<Classroom>>,
                                           IRequestHandler<GetAllClassroomsQuery, Response<List<Classroom>>>
    {
        private readonly IClassRoomService _classRoomService;
        public readonly ResponseHandler _responseHandler;

        public ClassRoomQueryHandler(IClassRoomService classRoomService, ResponseHandler responseHandler)
        {
            _classRoomService = classRoomService;
            _responseHandler = responseHandler;
        }
        public async Task<Response<Classroom>> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
        {
            var classroom = await _classRoomService.GetClassroomByIdAsync(request.ClassroomID);
            return _responseHandler.Success(classroom);
        }

        public async Task<Response<List<Classroom>>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
        {
            var classrooms = await _classRoomService.GetAllClassroomsAsync();
            return _responseHandler.Success(classrooms);
        }
    }
}
