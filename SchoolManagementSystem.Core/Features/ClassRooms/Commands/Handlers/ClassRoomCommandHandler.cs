using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Handlers
{
    internal class ClassRoomCommandHandler : IRequestHandler<AddClassroomCommand, Response<string>>,
                                             IRequestHandler<UpdateClassroomCommand, Response<string>>,
                                             IRequestHandler<DeleteClassroomCommand, Response<string>>,
                                             IRequestHandler<AddClassroomWithStudentsCommand, Response<string>>
    {
        private readonly IClassRoomService _classRoomService;
        private readonly IStudentService _studentService;
        public readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;


        public ClassRoomCommandHandler(IClassRoomService classRoomService, ResponseHandler responseHandler, IMapper mapper, IStudentService studentService)
        {
            _classRoomService = classRoomService;
            _responseHandler = responseHandler;
            _mapper = mapper;
            _studentService = studentService;
        }
        public async Task<Response<string>> Handle(AddClassroomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var roomMapper = _mapper.Map<Classroom>(request);
                await _classRoomService.AddclassRoomAsync(roomMapper);
                return _responseHandler.Created<string>("class room Created successfuly");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }
        public async Task<Response<string>> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var classroom = _mapper.Map<Classroom>(request);
                await _classRoomService.UpdateClassroomAsync(classroom);
                return _responseHandler.Success("Classroom updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            var result = await _classRoomService.DeleteClassroomAsync(request.ClassroomID);
            if (!result)
                return _responseHandler.NotFound<string>("Classroom Not Found .");

            return _responseHandler.Success("Classroom deleted successfully.");
        }

        public async Task<Response<string>> Handle(AddClassroomWithStudentsCommand request, CancellationToken cancellationToken)
        {
            var classroom = _mapper.Map<Classroom>(request);
            var students = await _studentService.GetStudentAsync();

            var result = await _classRoomService.AddClassroomWithStudentsAsync(classroom, students);

            if (result)
                return _responseHandler.Success("Classroom and students added successfully.");


            return _responseHandler.BadRequest<string>("Failed to add classroom and students.");
        }
    }
}
