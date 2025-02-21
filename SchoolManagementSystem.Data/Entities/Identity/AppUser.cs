using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Data.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpiryTime { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
