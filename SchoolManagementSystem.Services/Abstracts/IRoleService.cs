using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetAllRolesAsync();
        Task<bool> AddRoleAsync(string roleName);
        Task<bool> UpdateRoleAsync(string roleId, string newRoleName);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<List<RolesDetails>> GetUserRolesDetailsAsync(AppUser user);
        Task<bool> RoleExistsAsync(string roleName);
        Task<bool> RemoveAllRolesAsync(AppUser user);
        Task<bool> AssignRoleAsync(AppUser user, string roleName);

        Task<int> GetUserCountByRoleAsync(string roleName);  // stored procedure

    }
}
