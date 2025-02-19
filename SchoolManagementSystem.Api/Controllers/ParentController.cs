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


        [HttpGet("all")]
        public async Task<IActionResult> GetAllParents(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllParentsQuery(), cancellationToken);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetParentById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetParentByIdQuery(id), cancellationToken);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{parentId}/students")]
        public async Task<IActionResult> GetStudentsByParent(int parentId)
        {
            var result = await _mediator.Send(new GetStudentsByParentQuery { ParentID = parentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{parentId}/fee-history")]
        public async Task<IActionResult> GetFeePaymentHistoryByParent(int parentId)
        {
            var result = await _mediator.Send(new GetFeePaymentHistoryByParentQuery { ParentID = parentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddParent([FromBody] AddParentCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateParent([FromBody] UpdateParentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var result = await _mediator.Send(new DeleteParentCommand { ParentID = id });
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
