using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models;
using SchoolManagementSystem.Core.Features.ExamsTypes.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTypeController : BasicController
    {
        public ExamTypeController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExamTypes()
        {
            var result = await _mediator.Send(new GetAllExamTypesQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetExamTypeById(int id)
        {
            var result = await _mediator.Send(new GetExamTypeByIdQuery { ExamTypeID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddExamType([FromBody] AddExamTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetExamTypeById), new { id = result.Data }, result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateExamType([FromBody] UpdateExamTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExamType(int id)
        {
            var result = await _mediator.Send(new DeleteExamTypeCommand { ExamTypeID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }




    }
}
