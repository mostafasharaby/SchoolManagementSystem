using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Roles.Commands.Models;
using SchoolManagementSystem.Core.Features.Roles.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BasicController
    {
        public RolesController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpGet("get-roles")]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _mediator.Send(new GetRolesQuery());
            return response.Succeeded ? Ok(response) : NotFound(response);
        }


        [HttpGet("GetUserRoles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var query = new GetUserRolesByIdQuery { UserId = userId };
            var response = await _mediator.Send(query);
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpGet("count/{roleName}")]
        public async Task<IActionResult> GetUserCountByRole(string roleName)
        {
            var response = await _mediator.Send(new GetUserCountByRoleQuery(roleName));
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut("edit-role")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("delete-role/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var response = await _mediator.Send(new DeleteRoleCommand(roleId));
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }


    }
}
