using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using System.Security.Claims;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IClaimService
    {
        Task<List<ClaimDetails>> GetUserClaimsDetailsAsync(AppUser user);
        Task<bool> RemoveAllClaimsAsync(AppUser user);
        Task<bool> AddClaimsAsync(AppUser user, List<ClaimDetails> claims);
        Task<bool> AddOnlyClaimAsync(AppUser user, ClaimDetails claim);
        Task<bool> DeleteClaimAsync(AppUser user, ClaimDetails claim);
        Task<Claim> ClaimTypeExistsAsync(AppUser user, string claimType);
    }
}
