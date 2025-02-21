using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Courses.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Handlers
{
    public class CourseQueryHandler : IRequestHandler<GetCourseByIdQuery, Response<CourseDto>>,
                                      IRequestHandler<GetAllCoursesQuery, Response<List<CourseDto>>>,
                                      IRequestHandler<GetCoursesByDepartmentQuery, Response<List<CourseDto>>>,
                                      IRequestHandler<GetStudentsInCourseQuery, Response<List<StudentDto>>>,
                                      IRequestHandler<GetAssignmentsForCourseQuery, Response<List<AssignmentDto>>>,
                                      IRequestHandler<GetExamsForCourseQuery, Response<List<ExamDto>>>
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public CourseQueryHandler(ICourseService courseService, IMapper mapper, ResponseHandler responseHandler)
        {
            _courseService = courseService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<Response<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetCourseByIdAsync(request.CourseID);
            if (course == null)
                return _responseHandler.NotFound<CourseDto>("Course not found.");

            var dto = _mapper.Map<CourseDto>(course);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var dtoList = _mapper.Map<List<CourseDto>>(courses);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<CourseDto>>> Handle(GetCoursesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var courses = await _courseService.GetCoursesByDepartmentAsync(request.DepartmentID);
                var dtoList = _mapper.Map<List<CourseDto>>(courses);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<CourseDto>>(ex.Message);
            }
        }

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsInCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var students = await _courseService.GetStudentsInCourseAsync(request.CourseID);
                var dtoList = _mapper.Map<List<StudentDto>>(students);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<StudentDto>>(ex.Message);
            }
        }

        public async Task<Response<List<AssignmentDto>>> Handle(GetAssignmentsForCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var assignments = await _courseService.GetAssignmentsForCourseAsync(request.CourseID);
                var dtoList = _mapper.Map<List<AssignmentDto>>(assignments);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<AssignmentDto>>(ex.Message);
            }
        }

        public async Task<Response<List<ExamDto>>> Handle(GetExamsForCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exams = await _courseService.GetExamsForCourseAsync(request.CourseID);
                var dtoList = _mapper.Map<List<ExamDto>>(exams);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<ExamDto>>(ex.Message);
            }
        }
    }

}
