using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*
     {  
      "email": "mostafa@example.com"
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

            var response = await _mediator.Send(command);

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
    }
}
