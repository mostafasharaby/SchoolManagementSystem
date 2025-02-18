using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Features.Departments.Commands.Models;
using SchoolManagementSystem.Core.Features.Departments.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BasicController
    {
        public DepartmentController(IMediator _mediator) : base(_mediator) { }


        [HttpPost("add")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddDepartment), new { id = result.Data }, result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand { DepartmentID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var result = await _mediator.Send(new GetAllDepartmentsQuery());
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
