using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Handlers
{
    internal class LoginHandler : IRequestHandler<LoginCommand, Response<AuthResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        private readonly IConfiguration _Configuration;
        public LoginHandler(UserManager<AppUser> userManager, IMapper mapper, ResponseHandler responseHandler, IConfiguration Configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _Configuration = Configuration;
        }
        public async Task<Response<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser == null)
            {
                return _responseHandler.BadRequest<AuthResponse>("Invalid email or password.");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(existingUser, request.Password);
            if (!isPasswordValid)
            {
                return _responseHandler.BadRequest<AuthResponse>("Invalid email or password.");
            }
            var tokenGenerated = GenerateJwtToken(existingUser);

            var authResponse = new AuthResponse
            {
                Token = tokenGenerated,
                IsAuthenticated = true,
                UserName = existingUser.UserName
            };

            return _responseHandler.Success(authResponse);
        }

        private string GenerateJwtToken(AppUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentNullException(nameof(user.Id), "User Id cannot be null or empty");
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentNullException(nameof(user.Email), "User Email cannot be null or empty");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentNullException(nameof(user.UserName), "User Name cannot be null or empty");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Add roles to the claims
            var roles = _userManager.GetRolesAsync(user).Result;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // Add roles dynamically
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _Configuration["Jwt:ValidIssuer"],
                audience: _Configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
