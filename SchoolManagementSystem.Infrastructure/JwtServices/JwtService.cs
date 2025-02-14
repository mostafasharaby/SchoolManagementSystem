using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagementSystem.Infrastructure.JwtServices
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public AuthResponse GenerateJwtToken(AppUser user)
        {
            ValidateUser(user);

            var claims = GetClaimsForUser(user);
            var signingCredentials = GetSigningCredentials();

            var accessTokenExpiry = DateTime.UtcNow.AddHours(2);
            var refreshTokenExpiry = DateTime.UtcNow.AddHours(12);
            var (accessToken, tokenExpirationTime) = CreateJwtToken(claims, signingCredentials, accessTokenExpiry);
            var refreshToken = GenerateRefreshToken();

            UpdateUserTokens(user, accessToken, tokenExpirationTime, refreshToken, refreshTokenExpiry);

            return new AuthResponse
            {
                Token = accessToken,
                TokenExpiryTime = tokenExpirationTime,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = refreshTokenExpiry,
                UserName = user.UserName,
                IsAuthenticated = true,
                Message = "Authentication successful"
            };
        }

        private void ValidateUser(AppUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentNullException(nameof(user.Id), "User Id cannot be null or empty");
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentNullException(nameof(user.Email), "User Email cannot be null or empty");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentNullException(nameof(user.UserName), "User Name cannot be null or empty");
        }

        private List<Claim> GetClaimsForUser(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = _userManager.GetRolesAsync(user).Result;
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return claims;
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }
        private (string accessToken, DateTime TokenExpires) CreateJwtToken(IEnumerable<Claim> claims, SigningCredentials credentials, DateTime expiryTime)
        {
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:validissuer"],
                audience: _configuration["Jwt:validaudience"],
                claims: claims,
                expires: expiryTime,
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var tokenExpires = token.ValidTo;

            return (accessToken, tokenExpires);
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public AuthResponse RefreshToken(string expiredToken, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            try
            {

                var principal = GetClaimsPrincipalFromExpiredToken(expiredToken, tokenHandler, key);

                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    throw new SecurityTokenException("Invalid token");

                var user = _userManager.FindByIdAsync(userId).Result;
                ValidateRefreshToken(user, refreshToken);

                var refreshTokenExpiry = DateTime.UtcNow.AddMinutes(2);
                var (newAccessToken, newAccessTokenExpiry) = CreateJwtToken(principal.Claims, GetSigningCredentials(), refreshTokenExpiry);
                var newRefreshToken = GenerateRefreshToken();

                UpdateUserTokens(user, newAccessToken, newAccessTokenExpiry, newRefreshToken, refreshTokenExpiry);

                return new AuthResponse
                {
                    Token = newAccessToken,
                    RefreshToken = newRefreshToken,
                    TokenExpiryTime = newAccessTokenExpiry,
                    RefreshTokenExpiryTime = refreshTokenExpiry,
                    UserName = user.UserName,
                    IsAuthenticated = true,
                    Message = "Token refreshed successfully"
                };
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException($"Invalid token: {ex.Message}");
            }
        }

        private void UpdateUserTokens(AppUser user, string accessToken, DateTime accessTokenExpiry, string refreshToken, DateTime refreshTokenExpiry)
        {
            user.Token = accessToken;
            user.TokenExpiryTime = accessTokenExpiry;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = refreshTokenExpiry;
            _userManager.UpdateAsync(user).Wait();
        }
        private void ValidateRefreshToken(AppUser user, string refreshToken)
        {
            if (user == null)
                throw new SecurityTokenException("User not found");

            if (user.RefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new SecurityTokenException("Refresh token has expired");
        }


        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token, JwtSecurityTokenHandler tokenHandler, byte[] key)
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false, // Allow expired tokens
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:validissuer"],
                ValidAudience = _configuration["Jwt:validaudience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            if (validatedToken is JwtSecurityToken jwtTokens && jwtTokens.ValidTo > DateTime.UtcNow)
                throw new SecurityTokenException("Access token is still valid and donot not need to be refreshed.");

            if (!(validatedToken is JwtSecurityToken jwtToken) || jwtToken.Header.Alg != SecurityAlgorithms.HmacSha256)
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }

}
