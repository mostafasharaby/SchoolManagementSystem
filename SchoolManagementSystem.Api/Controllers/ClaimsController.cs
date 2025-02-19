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

        [HttpGet("roles-claims")]
        public async Task<IActionResult> GetUserRolesAndClaims()
        {
            var result = await _mediator.Send(new UserRoleClaimQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("roles-claims-grouped")]
        public async Task<IActionResult> GetGroupedUserRoleClaims()
        {
            var result = await _mediator.Send(new GetGroupedUserRoleClaimsQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserClaims(string userId)
        {
            var result = await _mediator.Send(new GetUserClaimsByIdQuery { UserId = userId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddClaim([FromBody] AddUserClaimCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteClaim([FromBody] DeleteUserClaimCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }





    }
}
