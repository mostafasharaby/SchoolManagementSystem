using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Infrastructure.JwtServices
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser user);
    }
}
