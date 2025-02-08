using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Data.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
