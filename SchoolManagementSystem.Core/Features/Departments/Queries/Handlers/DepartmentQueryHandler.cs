using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Departments.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Response<Department>>,
                                          IRequestHandler<GetAllDepartmentsQuery, Response<List<Department>>>,
                                          IRequestHandler<GetTeachersByDepartmentQuery, Response<List<TeacherDto>>>,
                                          IRequestHandler<GetCoursesByDepartmentQuery, Response<List<CourseDto>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public DepartmentQueryHandler(IMapper mapper, ResponseHandler responseHandler, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _departmentService = departmentService;
        }

        public async Task<Response<Department>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(request.DepartmentID);
            if (department == null)
                return _responseHandler.NotFound<Department>("Department not found.");

            var dto = _mapper.Map<Department>(department);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<Department>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var dtoList = _mapper.Map<List<Department>>(departments);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<TeacherDto>>> Handle(GetTeachersByDepartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var teachers = await _departmentService.GetTeachersByDepartmentAsync(request.DepartmentID);
                var dtoList = _mapper.Map<List<TeacherDto>>(teachers);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<TeacherDto>>(ex.Message);

            }
        }

        public async Task<Response<List<CourseDto>>> Handle(GetCoursesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var courses = await _departmentService.GetCoursesByDepartmentAsync(request.DepartmentID);
                var dtoList = _mapper.Map<List<CourseDto>>(courses);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<CourseDto>>(ex.Message);
            }
        }
    }
}
