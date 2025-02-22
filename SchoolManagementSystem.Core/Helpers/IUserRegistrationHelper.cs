using AngularApi.Services;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities.Identity;
using System.Net;

namespace SchoolManagementSystem.Core.Helpers
{
    public interface IUserRegistrationHelper
    {
        Task<Response<string>> RegisterUserAsync(AppUser user, string password, string role);
    }
    public class UserRegistrationHelper : IUserRegistrationHelper
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly ResponseHandler _responseHandler;

        public UserRegistrationHelper(UserManager<AppUser> userManager,
                                       IEmailService emailService,
                                       ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _emailService = emailService;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> RegisterUserAsync(AppUser user, string password, string role)
        {
            var existingUserEmail = await _userManager.FindByEmailAsync(user.Email);
            if (existingUserEmail != null)
                return _responseHandler.BadRequest<string>("Email is already in use.");

            var existingUserName = await _userManager.FindByNameAsync(user.UserName);
            if (existingUserName != null)
                return _responseHandler.BadRequest<string>("UserName is already in use.");

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            await _userManager.AddToRoleAsync(user, role);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"http://localhost:5253/api/Account/confirm-email?userId={user.Id}&token={WebUtility.UrlEncode(token)}";

            var emailBody = $"Hello {user.UserName},<br> Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.";
            var message = new Message(new[] { user.Email }, "Confirm Your Email", emailBody);

            try
            {
                _emailService.SendEmail(message);
                return _responseHandler.Success(user.Id, "Account created successfully. Please check your email to confirm your account.");
            }
            catch (Exception)
            {
                return _responseHandler.BadRequest<string>("Failed to send confirmation email.");
            }
        }
    }

}
