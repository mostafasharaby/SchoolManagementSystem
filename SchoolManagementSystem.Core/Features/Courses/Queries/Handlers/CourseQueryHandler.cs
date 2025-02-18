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
                                      IRequestHandler<GetCoursesByDepartmentQuery, Response<List<CourseDto>>>
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
            var courses = await _courseService.GetCoursesByDepartmentAsync(request.DepartmentID);
            var dtoList = _mapper.Map<List<CourseDto>>(courses);
            return _responseHandler.Success(dtoList);
        }
    }

}
