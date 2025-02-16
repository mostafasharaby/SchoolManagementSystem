using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Data.Views;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;
using System.Security.Claims;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ClaimService : IClaimService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRolesClaimsRepository _userRolesClaimsRepository;

        public ClaimService(IUserRolesClaimsRepository userRolesClaimsRepository, UserManager<AppUser> userManager)
        {
            _userRolesClaimsRepository = userRolesClaimsRepository;
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

        public async Task<List<UserRolesClaimsView>> GetUserClaimsDetailsAsync()
        {
            return await _userRolesClaimsRepository.GetAllUserRoleClaims();
        }

        public async Task<List<UserRoleClaimGroupedDto>> GetGroupedUserClaimsAsync()
        {
            var roleClaims = await GetUserClaimsDetailsAsync();

            var groupedData = roleClaims
                .GroupBy(urc => new { urc.UserId, urc.UserName })
                .Select(group => new UserRoleClaimGroupedDto
                {
                    UserId = group.Key.UserId,
                    UserName = group.Key.UserName,
                    Roles = group.Select(rc => rc.RoleName).Distinct().ToList(),
                    Claims = group
                        .Where(rc => !string.IsNullOrEmpty(rc.ClaimType))
                        .Select(rc => new ClaimDto
                        {
                            ClaimType = rc.ClaimType,
                            ClaimValue = rc.ClaimValue
                        })
                        .Distinct()
                        .ToList()
                })
                .ToList();

            return groupedData;
        }
    }
}
