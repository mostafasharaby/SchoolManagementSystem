using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Parents.Commands.Models;
using SchoolManagementSystem.Core.Features.Parents.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : BasicController
    {
        public ParentController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpPost("add")]
        public async Task<IActionResult> AddParent([FromBody] AddParentCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetParentById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetParentByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllParents(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllParentsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateParent([FromBody] UpdateParentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var result = await _mediator.Send(new DeleteParentCommand { ParentID = id });
            return Ok(result);
        }
    }
}
