using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Data.Entities.RefreshToken
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryTime { get; set; }
        public bool IsRevoked { get; set; } = false;
        public bool IsUsed { get; set; } = false;
        public string? ReplacedByToken { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }

}
