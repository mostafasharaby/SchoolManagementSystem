using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Data.Entities.Identity;
using System.Security.Claims;

namespace AngularApi.Services
{
    public interface IUserService
    {
        Task<AppUser> GetCurrentUserAsync();
        Task<AppUser?> FindUserByIdAsync(string userId);
        Task<AppUser?> FindUserByEmailAsync(string email);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser?> FindUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<AppUser> GetCurrentUserAsync()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                throw new InvalidOperationException("HttpContext is null");
            }

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new InvalidOperationException("User ID not found");
            }

            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }


    }
}
