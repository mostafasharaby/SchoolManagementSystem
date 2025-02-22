using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Core.Helpers;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Handlers
{
    public class AppUserHandler : IRequestHandler<RegisterAdminCommand, Response<string>>,
                                   IRequestHandler<RegisterStudentCommand, Response<string>>,
                                   IRequestHandler<RegisterTeacherCommand, Response<string>>,
                                   IRequestHandler<UpdateAppUserCommand, Response<AppUserDto>>,
                                   IRequestHandler<UpdateProfileRequest, Response<string>>,
                                   IRequestHandler<DeleteAppUserCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        private readonly IUserRegistrationHelper _userRegistrationHelper;
        private readonly IValidationService _validationService;


        public AppUserHandler(UserManager<AppUser> userManager, IMapper mapper, ResponseHandler responseHandler, IUserRegistrationHelper userRegistrationHelper,
                                IValidationService validationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _userRegistrationHelper = userRegistrationHelper;
            _validationService = validationService;
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
        public async Task<Response<string>> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request);
            return await _userRegistrationHelper.RegisterUserAsync(user, request.Password, "admin");
            #region  Old_Way
            //var existingUserEmail = await _userManager.FindByEmailAsync(user.Email);
            //if (existingUserEmail != null)
            //    return _responseHandler.BadRequest<string>("Email is already in use.");

            //var existingUserName = await _userManager.FindByNameAsync(user.UserName);
            //if (existingUserName != null)
            //    return _responseHandler.BadRequest<string>("UserName is already in use.");

            //var result = await _userManager.CreateAsync(user, password);
            //if (!result.Succeeded)
            //{
            //    return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
            //}

            //await _userManager.AddToRoleAsync(user, role);

            //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //var confirmationLink = $"http://localhost:5253/api/Account/confirm-email?userId={user.Id}&token={WebUtility.UrlEncode(token)}";

            //var emailBody = $"Hello {user.UserName},<br> Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.";
            //var message = new Message(new[] { user.Email }, "Confirm Your Email", emailBody);

            //try
            //{
            //    _emailService.SendEmail(message);
            //    return _responseHandler.Success(user.Id, "Account created successfully. Please check your email to confirm your account.");
            //}
            //catch (Exception)
            //{
            //    return _responseHandler.BadRequest<string>("Failed to send confirmation email.");
            //}
            #endregion
        }

        public async Task<Response<string>> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validationService.ValidateClassRoomExistsAsync(request.ClassroomID);
                await _validationService.ValidateParentExistsAsync(request.ParentID);

                var student = _mapper.Map<Student>(request);
                return await _userRegistrationHelper.RegisterUserAsync(student, request.Password, "student");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }
        public async Task<Response<string>> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validationService.ValidateDepartmentExistsAsync(request.DepartmentID);

                var student = _mapper.Map<Teacher>(request);
                return await _userRegistrationHelper.RegisterUserAsync(student, request.Password, "teacher");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
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
