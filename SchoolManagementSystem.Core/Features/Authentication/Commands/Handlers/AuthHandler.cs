using AngularApi.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.GoogleServices;
using SchoolManagementSystem.Infrastructure.JwtServices;
using System.Net;
using System.Security.Claims;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Handlers
{
    internal class AuthHandler : IRequestHandler<LoginCommand, Response<AuthResponse>>,
                                 IRequestHandler<ChangePasswordCommand, Response<string>>,
                                 IRequestHandler<ForgotPasswordCommand, Response<string>>,
                                 IRequestHandler<ResetPasswordCommand, Response<string>>,
                                 IRequestHandler<GoogleLoginCommand, AuthenticationProperties>,
                                 IRequestHandler<GoogleLoginCallbackCommand, string>,
                                 IRequestHandler<ConfirmEmailCommand, Response<AppUser>>

    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;
        private readonly IGoogleService _googleService;
        public AuthHandler(UserManager<AppUser> userManager, IMapper mapper, ResponseHandler responseHandler,
                          IHttpContextAccessor httpContextAccessor, IEmailService emailService, IJwtService jwtService,
                          IGoogleService googleService)

        {
            _userManager = userManager;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _jwtService = jwtService;
            _googleService = googleService;
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
            var tokenGenerated = _jwtService.GenerateJwtToken(existingUser);

            var authResponse = new AuthResponse
            {
                Token = tokenGenerated,
                IsAuthenticated = true,
                UserName = existingUser.UserName
            };

            return _responseHandler.Success(authResponse);
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return _responseHandler.Unauthorized<string>();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return _responseHandler.NotFound<string>("المستخدم غير موجود.");

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));

            return _responseHandler.Success("تم تغيير كلمة المرور بنجاح.");
        }

        public async Task<Response<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return _responseHandler.BadRequest<string>("User not found.");

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(resetToken);
            //var resetLink = $"http://localhost:4200/auth/reset-password?token={encodedToken}&email={request.Email}";

            //var message = new Message(new[] { user.Email }, "Forgot Password Link", resetLink);

            //try
            //{
            //    _emailService.SendEmail(message);
            //    return _responseHandler.Success("Password reset link sent successfully.");
            //}
            //catch (Exception)
            //{
            //    return _responseHandler.BadRequest<string>("Failed to send email.");
            //}


            return _responseHandler.Success(resetToken);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return _responseHandler.BadRequest<string>("User not found.");

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            // i have check on the token in ResetPasswordCommandValidator 
            if (!result.Succeeded)
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));

            return _responseHandler.Success("Password has been reset successfully.");
        }

        public async Task<AuthenticationProperties> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_googleService.GetGoogleLoginProperties(request.RedirectUri));
            //Task.FromResult -> return the result asynchronously. 
        }

        public async Task<string> Handle(GoogleLoginCallbackCommand request, CancellationToken cancellationToken)
        {
            return await _googleService.GoogleLoginCallbackAsync();
        }

        public async Task<Response<AppUser>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.BadRequest<AppUser>("User not found.");

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (!result.Succeeded)
                return _responseHandler.BadRequest<AppUser>("Email confirmation failed");

            return _responseHandler.Success<AppUser>(user, "Email confirmed successfully.");
        }
    }
}
