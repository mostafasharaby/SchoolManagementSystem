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


        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateFeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteFeeCommand { FeeID = id });
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFeesQuery());
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetFeeByIdQuery { FeeID = id });
            return Ok(result);
        }
    }
}
