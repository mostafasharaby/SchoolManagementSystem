using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Departments.Queries.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Response<Department>>,
                                        IRequestHandler<GetAllDepartmentsQuery, Response<List<Department>>>
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
    }
}
