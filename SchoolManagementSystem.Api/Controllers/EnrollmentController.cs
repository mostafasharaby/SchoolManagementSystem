using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Enrollments.Commands.Models;
using SchoolManagementSystem.Core.Features.Enrollments.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : BasicController
    {
        public EnrollmentController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }


        [HttpPost("add")]
        public async Task<IActionResult> AddEnrollment([FromBody] AddEnrollmentCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEnrollment([FromBody] UpdateEnrollmentCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var result = await _mediator.Send(new DeleteEnrollmentCommand { EnrollmentID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var result = await _mediator.Send(new GetEnrollmentByIdQuery { EnrollmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var result = await _mediator.Send(new GetAllEnrollmentsQuery());
            return Ok(result);
        }
    }
}
