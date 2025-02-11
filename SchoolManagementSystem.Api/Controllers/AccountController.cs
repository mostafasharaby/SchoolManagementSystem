using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Models;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using System.Security.Claims;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*
     {  
      "email": "mostafa@example.com",
      "password": "P@ssw0rd!"
     }
     */
    public class AccountController : BasicController
    {
        public AccountController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                return NewResult(_responseHandler.BadRequest<AppUser>("Invalid request data."));
            }

            var response = await _mediator.Send(command); // It sends a command to a corresponding handler, which then executes the necessary business logic

            if (!response.Succeeded)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.Succeeded)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var command = new AppUserDtoCommamd(userId);
            var response = await _mediator.Send(command);

            if (!response.Succeeded)
                return NewResult(_responseHandler.Unauthorized<AppUser>());

            return Ok(response);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersDtoCommand());

            if (!result.Succeeded)
                return NotFound(result); // 404 if no users found

            return Ok(result); // 200 with user list
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateAppUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            var response = await _mediator.Send(command);
            if (!response.Succeeded)
            {
                return BadRequest(response); // Returns validation errors or update errors
            }

            return Ok(response);
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileCommand command)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NewResult(_responseHandler.Unauthorized<AppUser>());

            var response = await _mediator.Send(new UpdateProfileRequest(userId, command));
            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return NewResult(_responseHandler.Unauthorized<AppUser>());

            var command = new DeleteAppUserCommand { Id = userId };
            var response = await _mediator.Send(command);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var command = new DeleteAppUserCommand { Id = userId };
            var response = await _mediator.Send(command);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return NewResult(_responseHandler.Unauthorized<AppUser>());


            var response = await _mediator.Send(command);
            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }


        [HttpGet("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle()
        {
            var properties = await _mediator.Send(new GoogleLoginCommand { RedirectUri = Url.Action(nameof(GoogleLoginCallback)) });
            return Challenge(properties, "Google"); // Challenge method sends the user to Google's OAuth login page.
        }

        [HttpGet("GoogleLoginCallback")]
        public async Task<IActionResult> GoogleLoginCallback()
        {
            var token = await _mediator.Send(new GoogleLoginCallbackCommand());
            return Ok(new { Token = token });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token) // from query as i fetch it from query params 
        {
            var result = await _mediator.Send(new ConfirmEmailCommand(userId, token));
            if (!result.Succeeded) return NewResult(_responseHandler.BadRequest<AppUser>(result.Message));

            return Ok(new { Message = result });
        }

    }
}
