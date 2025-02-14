using AngularApi.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagementSystem.Data.Entities.Identity;
using System.Net;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Handlers
{
    public class AppUserHandler : IRequestHandler<RegisterCommand, Response<string>>,
                                   IRequestHandler<UpdateAppUserCommand, Response<AppUserDto>>,
                                   IRequestHandler<UpdateProfileRequest, Response<string>>,
                                   IRequestHandler<DeleteAppUserCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        private readonly IEmailService _emailService;


        public AppUserHandler(UserManager<AppUser> userManager, IMapper mapper, IEmailService emailService, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _emailService = emailService;
        }

        //public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        //{
        //    var existingUser = await _userManager.FindByEmailAsync(request.Email);
        //    if (existingUser != null)
        //    {
        //        return _responseHandler.BadRequest<string>("Email is already in use.");
        //    }

        //    var user = _mapper.Map<AppUser>(request);
        //    var result = await _userManager.CreateAsync(user, request.Password);

        //    if (!result.Succeeded)
        //    {
        //        return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
        //    }

        //    return _responseHandler.Success(user.Id, "User registered successfully.");
        //}
        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUserEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingUserEmail != null)
                return _responseHandler.BadRequest<string>("Email is already in use.");

            var existingUserName = await _userManager.FindByNameAsync(request.UserName);

            if (existingUserName != null)
                return _responseHandler.BadRequest<string>("UserName is already in use.");


            var user = _mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            await _userManager.AddToRoleAsync(user, "student");
            await _userManager.AddToRoleAsync(user, "admin");  //              ------------ 

            if (!result.Succeeded)
            {
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

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

        public async Task<Response<AppUserDto>> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return _responseHandler.NotFound<AppUserDto>("User not found.");
            }

            _mapper.Map(request, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return _responseHandler.BadRequest<AppUserDto>(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var updatedUserDto = _mapper.Map<AppUserDto>(user);
            return _responseHandler.Success(updatedUserDto);
        }

        public async Task<Response<string>> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.NotFound<string>("User not found.");

            _mapper.Map(request.Command, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));

            return _responseHandler.Success("Profile updated successfully.");
        }

        public async Task<Response<string>> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return _responseHandler.NotFound<string>("User not found.");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));

            return _responseHandler.Success("Account deleted successfully.");
        }
    }
}
