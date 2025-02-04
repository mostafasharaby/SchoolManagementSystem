using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _mediator.Send(new GetAllTeachersQuery());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _mediator.Send(new GetStudentByIdQuery(id));

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherCommand command)
        {
            if (id != command.TeacherID) return BadRequest("Teacher ID mismatch.");

            var result = await _mediator.Send(command);
            if (result == null) return NotFound("Teacher not found.");

            return Ok("Teacher updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand(id));
            if (!result) return NotFound("Teacher not found.");

            return Ok("Teacher deleted successfully.");
        }

    }
}
