using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Handlers
{
    internal class TeacherQueryHandler : IRequestHandler<GetTeacherByIdQuery, Response<TeacherDto>>,
                                         IRequestHandler<GetAllTeachersQuery, Response<List<TeacherDto>>>,
                                         IRequestHandler<GetTeachersByDepartmentQuery, Response<List<TeacherDto>>>,
                                           IRequestHandler<GetCoursesByTeacherQuery, Response<List<CourseDto>>>,
                                           IRequestHandler<GetClassroomsByTeacherQuery, Response<List<ClassroomDto>>>,
                                           IRequestHandler<GetStudentsInClassroomQuery, Response<List<StudentDto>>>,
                                           IRequestHandler<GetExamResultsByCourseQuery, Response<List<ExamResultDto>>>
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public TeacherQueryHandler(IMapper mapper, ResponseHandler responseHandler, ITeacherService teacherService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _teacherService = teacherService;
        }

        public async Task<Response<TeacherDto>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.GetTeachersByIdAsync(request.TeacherID);
            if (teacher == null)
                return _responseHandler.NotFound<TeacherDto>("Teacher not found.");

            var dto = _mapper.Map<TeacherDto>(teacher);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<TeacherDto>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherService.GetTeachersAsync();
            var dtoList = _mapper.Map<List<TeacherDto>>(teachers);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<TeacherDto>>> Handle(GetTeachersByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(request.DepartmentID);
            var dtoList = _mapper.Map<List<TeacherDto>>(teachers);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<CourseDto>>> Handle(GetCoursesByTeacherQuery request, CancellationToken cancellationToken)
        {
            var courses = await _teacherService.GetCoursesByTeacherAsync(request.TeacherID);
            var response = _mapper.Map<List<CourseDto>>(courses);
            return _responseHandler.Success(response);
        }

        public async Task<Response<List<ClassroomDto>>> Handle(GetClassroomsByTeacherQuery request, CancellationToken cancellationToken)
        {
            var classrooms = await _teacherService.GetClassroomsByTeacherAsync(request.TeacherID);
            var response = _mapper.Map<List<ClassroomDto>>(classrooms);
            return _responseHandler.Success(response);
        }

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsInClassroomQuery request, CancellationToken cancellationToken)
        {
            var students = await _teacherService.GetStudentsInClassroomAsync(request.TeacherID, request.ClassroomID);
            var response = _mapper.Map<List<StudentDto>>(students);
            return _responseHandler.Success(response);
        }

        public async Task<Response<List<ExamResultDto>>> Handle(GetExamResultsByCourseQuery request, CancellationToken cancellationToken)
        {
            var examResults = await _teacherService.GetExamResultsByCourseAsync(request.TeacherID, request.CourseID);
            var response = _mapper.Map<List<ExamResultDto>>(examResults);
            return _responseHandler.Success(response);
        }

    }
}
