using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Departments.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, Response<string>>,
                                         IRequestHandler<UpdateDepartmentCommand, Response<string>>,
                                         IRequestHandler<DeleteDepartmentCommand, Response<string>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public DepartmentCommandHandler(IMapper mapper, ResponseHandler responseHandler, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _departmentService = departmentService;
        }

        public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);
            await _departmentService.AddDepartmentAsync(department);
            return _responseHandler.Created("Department created successfully.");
        }

        public async Task<Response<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var department = _mapper.Map<Department>(request);
                await _departmentService.UpdateDepartmentAsync(department);
                return _responseHandler.Success("Department updated successfully.");
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

        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.DeleteDepartmentAsync(request.DepartmentID);
            if (!result)
                return _responseHandler.NotFound<string>("Department not found.");

            return _responseHandler.Success("Department deleted successfully.");
        }
    }
}
