using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Services.Abstracts;
using System.Security.Claims;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ClaimService : IClaimService
    {
        private readonly UserManager<AppUser> _userManager;

        public ClaimService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ClaimDetails>> GetUserClaimsDetailsAsync(AppUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            return claims.Select(c => new ClaimDetails { Type = c.Type, Value = c.Value }).ToList();
        }

        public async Task<bool> RemoveAllClaimsAsync(AppUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in claims)
            {
                await _userManager.RemoveClaimAsync(user, claim);
            }
            return true;
        }

        public async Task<bool> AddClaimsAsync(AppUser user, List<ClaimDetails> claims)
        {
            var claimObjects = claims.Select(c => new Claim(c.Type, c.Value)).ToList();
            var result = await _userManager.AddClaimsAsync(user, claimObjects);
            return result.Succeeded;
        }

        public async Task<bool> AddOnlyClaimAsync(AppUser user, ClaimDetails claim)
        {
            var result = await _userManager.AddClaimAsync(user, new Claim(claim.Type, claim.Value));
            return result.Succeeded;
        }

        public async Task<bool> DeleteClaimAsync(AppUser user, ClaimDetails claim)
        {
            var result = await _userManager.RemoveClaimAsync(user, new Claim(claim.Type, claim.Value));
            return result.Succeeded;
        }

        public async Task<Claim> ClaimTypeExistsAsync(AppUser user, string claimType)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var result = claims.FirstOrDefault(item => item.Type == claimType);
            return result;
        }
    }
}
