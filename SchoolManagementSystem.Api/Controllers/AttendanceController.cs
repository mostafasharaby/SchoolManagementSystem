using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Features.Attendances.Commands.Models;
using SchoolManagementSystem.Core.Features.Attendances.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : BasicController
    {
        public AttendanceController(IMediator _mediator) : base(_mediator) { }



        [HttpPost("add")]
        public async Task<IActionResult> AddAttendance([FromBody] AddAttendanceCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAttendance([FromBody] UpdateAttendanceCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var result = await _mediator.Send(new DeleteAttendanceCommand { AttendanceID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var result = await _mediator.Send(new GetAttendanceByIdQuery { AttendanceID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAttendances()
        {
            var result = await _mediator.Send(new GetAllAttendancesQuery());
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
