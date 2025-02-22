using AngularApi.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Helpers;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Services.Abstracts;
namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<UpdateStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IValidationService _validationService;
        private readonly IUserRegistrationHelper _userRegistrationHelper;
        public StudentCommandHandler(IMapper mapper, ResponseHandler responseHandler, IStudentService studentService, UserManager<AppUser> userManager, IEmailService emailService,
            IValidationService validationService, IUserRegistrationHelper userRegistrationHelper)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _studentService = studentService;
            _userManager = userManager;
            _emailService = emailService;
            _validationService = validationService;
            _userRegistrationHelper = userRegistrationHelper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validationService.ValidateClassRoomExistsAsync(request.ClassroomID);
                await _validationService.ValidateParentExistsAsync(request.ParentID);

                var student = _mapper.Map<Student>(request);
                return await _userRegistrationHelper.RegisterUserAsync(student, request.Password, "student");
                #region old-Way
                //var existingUserEmail = await _userManager.FindByEmailAsync(request.Email);
                //if (existingUserEmail != null)
                //    return _responseHandler.BadRequest<string>("Email is already in use.");

                //var existingUserName = await _userManager.FindByNameAsync(request.UserName);

                //if (existingUserName != null)
                //    return _responseHandler.BadRequest<string>("UserName is already in use.");


                //var user = _mapper.Map<Student>(request);
                //var result = await _userManager.CreateAsync(user, request.Password);
                //await _userManager.AddToRoleAsync(user, "student");
                ////  await _userManager.AddToRoleAsync(user, "admin");  //              ------------ 

                //if (!result.Succeeded)
                //{
                //    return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
                //}

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
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = _mapper.Map<Student>(request);
                await _studentService.UpdateStudentAsync(student);
                return _responseHandler.Success("Student updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest<string>("An unexpected error occurred: " + ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.DeleteStudentAsync(request.StudentID);
            if (!result)
                return _responseHandler.NotFound<string>("Student not found.");

            return _responseHandler.Success("Student deleted successfully.");
        }
    }

}
