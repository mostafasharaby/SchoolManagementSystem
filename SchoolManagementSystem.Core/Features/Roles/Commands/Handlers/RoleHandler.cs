using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Roles.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Handlers
{
    internal class RoleHandler : IRequestHandler<AddRoleCommand, Response<string>>,
                                 IRequestHandler<EditRoleCommand, Response<string>>,
                                 IRequestHandler<DeleteRoleCommand, Response<string>>,
                                 IRequestHandler<UpdateUserRoleCommand, Response<string>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly ResponseHandler _responseHandler;
        public readonly IRoleService _roleService;
        public readonly UserManager<AppUser> _userManager;

        public RoleHandler(RoleManager<IdentityRole> roleManager, ResponseHandler responseHandler, IRoleService roleService, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _responseHandler = responseHandler;
            _roleService = roleService;
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var success = await _roleService.AddRoleAsync(request.RoleName);
            if (!success)
                return _responseHandler.BadRequest<string>("This Role is Already Exist");

            return _responseHandler.Success<string>("This Role is Created Successfully");
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var success = await _roleService.UpdateRoleAsync(request.RoleId, request.NewRoleName);
            if (!success)
                return _responseHandler.BadRequest<string>("Role not found");

            return _responseHandler.Success("Role updated successfully");
        }
        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId);
            if (role == null)
                return _responseHandler.BadRequest<string>("Role not found");

            await _roleManager.DeleteAsync(role);
            return _responseHandler.Success<string>("Role deleted successfully");
        }

        public async Task<Response<string>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.BadRequest<string>("User not found");

            var roleExists = await _roleService.RoleExistsAsync(request.RoleName);
            if (!roleExists)
                return _responseHandler.BadRequest<string>("Role not found");

            // very smart way to  Remove only the specified old role
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(request.OldRoleName))
                return _responseHandler.BadRequest<string>($"User is not assigned to the role '{request.OldRoleName}'");

            var removed = await _userManager.RemoveFromRoleAsync(user, request.OldRoleName);
            if (!removed.Succeeded)
                return _responseHandler.BadRequest<string>("Failed to remove the old role");


            var assigned = await _roleService.AssignRoleAsync(user, request.RoleName);
            if (!assigned)
                return _responseHandler.BadRequest<string>("Failed to update user role");

            return _responseHandler.Success<string>("User role updated successfully");
        }
    }


}
