using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Claims.Commands.Models;
using SchoolManagementSystem.Core.Features.Claims.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserClaims(string userId)
        {
            var response = await _mediator.Send(new GetUserClaimsByIdQuery { UserId = userId });
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddClaim([FromBody] AddUserClaimCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteClaim([FromBody] DeleteUserClaimCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
