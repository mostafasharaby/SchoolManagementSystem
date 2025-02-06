using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Results;
using SchoolManagementSystem.Api.AppRouting;
namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Routing.TeacherRouting.List)]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _mediator.Send(new GetAllTeachersQuery());
        }
        [HttpGet(Routing.TeacherRouting.ById)]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _mediator.Send(new GetTeacherByIdQuery(id));

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpGet("Dto")]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeacherDto()
        {
            return await _mediator.Send(new GetTeacherDtoQuery());
        }

        [HttpPut(Routing.TeacherRouting.Update)]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherCommand command)
        {
            if (id != command.TeacherID) return BadRequest("Teacher ID mismatch.");

            var result = await _mediator.Send(command);
            if (result == null) return NotFound("Teacher not found.");

            return Ok("Teacher updated successfully.");
        }

        [HttpDelete(Routing.TeacherRouting.Delete)]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand(id));
            if (!result) return NotFound("Teacher not found.");

            return Ok("Teacher deleted successfully.");
        }

    }
}
