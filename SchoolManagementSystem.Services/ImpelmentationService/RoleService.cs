using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImplementationService
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SchoolContext _context;


        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SchoolContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<RoleResponse>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles
                .Select(r => new RoleResponse { Id = r.Id, Name = r.Name })
                .ToListAsync();

            return roles;
        }

        public async Task<List<RolesDetails>> GetUserRolesDetailsAsync(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return _roleManager.Roles
                .Where(r => roles.Contains(r.Name))
                .Select(r => new RolesDetails { Id = r.Id, Name = r.Name })
                .ToList();
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> RemoveAllRolesAsync(AppUser user)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            return result.Succeeded;
        }

        public async Task<bool> AssignRoleAsync(AppUser user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> AddRoleAsync(string roleName)
        {
            var existRole = await _roleManager.RoleExistsAsync(roleName);
            if (existRole)
            {
                return false; // Role already exists
            }

            var role = new IdentityRole { Name = roleName };
            await _roleManager.CreateAsync(role);
            return true;
        }

        public async Task<bool> UpdateRoleAsync(string roleId, string newRoleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return false;

            role.Name = newRoleName;
            await _roleManager.UpdateAsync(role);
            return true;
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return false;

            await _roleManager.DeleteAsync(role);
            return true;
        }

        public Task<List<RolesDetails>> GetUserRolesDetailsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }


        public async Task<int> GetUserCountByRoleAsync(string roleName)
        {
            return await _context.UserRoles
                .Where(ur => _context.Roles.Any(r => r.Id == ur.RoleId && r.Name == roleName))  //[AspNetUserRoles]
                .CountAsync();
        }
    }
}
