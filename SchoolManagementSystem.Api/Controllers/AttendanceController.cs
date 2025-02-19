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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAttendances()
        {
            var result = await _mediator.Send(new GetAllAttendancesQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var result = await _mediator.Send(new GetAttendanceByIdQuery { AttendanceID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{classroomId}/attendance-summary")]
        public async Task<IActionResult> GetAttendanceSummary(int classroomId)
        {
            var result = await _mediator.Send(new GetAttendanceSummaryQuery { ClassroomID = classroomId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost("{classroomId}/attendance")]
        public async Task<IActionResult> MarkAttendance(int classroomId, [FromBody] MarkAttendanceCommand command)
        {
            command.ClassroomID = classroomId;
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAttendance([FromBody] AddAttendanceCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAttendance([FromBody] UpdateAttendanceCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var result = await _mediator.Send(new DeleteAttendanceCommand { AttendanceID = id });
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

    }
}
