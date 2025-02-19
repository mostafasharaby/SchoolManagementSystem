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


        [HttpGet("all")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var result = await _mediator.Send(new GetAllDepartmentsQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand { DepartmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

    }
}
