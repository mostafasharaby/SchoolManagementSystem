using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Infrastructure.JwtServices
{
    public interface IJwtService
    {
        Task<AuthResponse> GenerateJwtToken(AppUser user);
        Task<AuthResponse> RefreshToken(string expiredToken, string refreshToken);
    }
}
