using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Infrastructure.JwtServices
{
    public interface IJwtService
    {
        AuthResponse GenerateJwtToken(AppUser user);
        AuthResponse RefreshToken(string expiredToken, string refreshToken);
    }
}
