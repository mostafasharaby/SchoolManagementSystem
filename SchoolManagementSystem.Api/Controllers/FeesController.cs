using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Fees.Commands.Models;
using SchoolManagementSystem.Core.Features.Fees.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : BasicController
    {
        public FeesController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFeesQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{studentId}/outstanding-fees")]
        public async Task<IActionResult> GetOutstandingFees(string studentId)
        {
            var result = await _mediator.Send(new GetOutstandingFeesQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetFeeByIdQuery { FeeID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateFeeCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFeeCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteFeeCommand { FeeID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


    }
}
