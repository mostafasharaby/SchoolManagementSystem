
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Roles.Queries.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Roles.Queries.Handlers
{
    internal class GetRolesHandler : IRequestHandler<GetRolesQuery, Response<List<RoleResponse>>>,
                                     IRequestHandler<GetUserRolesByIdQuery, Response<UserRoles>>,
                                     IRequestHandler<GetUserCountByRoleQuery, Response<int>>

    {
        private readonly ResponseHandler _responseHandler;
        public readonly IRoleService _roleService;
        public readonly UserManager<AppUser> _userManager;

        public GetRolesHandler(ResponseHandler responseHandler, IRoleService roleService, UserManager<AppUser> userManager)
        {
            _responseHandler = responseHandler;
            _roleService = roleService;
            _userManager = userManager;
        }
        public async Task<Response<List<RoleResponse>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllRolesAsync();
            return _responseHandler.Success(roles, "Roles retrieved successfully");
        }

        public async Task<Response<UserRoles>> Handle(GetUserRolesByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.NotFound<UserRoles>("User not found");


            var rolesDetails = await _roleService.GetUserRolesDetailsAsync(user);
            var UserRoles = new UserRoles
            {
                UserId = user.Id,
                RolesDetails = rolesDetails
            };

            return _responseHandler.Success(UserRoles, "User roles retrieved successfully");
        }

        public async Task<Response<int>> Handle(GetUserCountByRoleQuery request, CancellationToken cancellationToken)
        {
            var count = await _roleService.GetUserCountByRoleAsync(request.RoleName);
            return _responseHandler.Success(count, "User count retrieved successfully.");
        }
    }
}
