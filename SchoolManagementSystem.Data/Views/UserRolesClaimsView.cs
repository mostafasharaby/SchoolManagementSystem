using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Data.Views
{
    [Keyless]
    public class UserRolesClaimsView
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

    public class UserRoleClaimGroupedDto
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public List<string> Roles { get; set; } = new();
        public List<ClaimDto> Claims { get; set; } = new();
    }

    public class ClaimDto
    {
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

}
