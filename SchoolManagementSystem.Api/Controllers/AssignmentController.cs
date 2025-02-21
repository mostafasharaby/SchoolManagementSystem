using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Assignments.Commands.Models;
using SchoolManagementSystem.Core.Features.Assignments.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : BasicController
    {
        public AssignmentController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAssignments()
        {
            var result = await _mediator.Send(new GetAllAssignmentsQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            var result = await _mediator.Send(new GetAssignmentByIdQuery { AssignmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpGet("by-course/{courseId}")]
        public async Task<IActionResult> GetAssignmentsByCourse(int courseId)
        {
            var result = await _mediator.Send(new GetAssignmentsByCourseQuery { CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddAssignment([FromBody] AddAssignmentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddAssignment), new { id = result }, new { Id = result });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAssignment([FromBody] UpdateAssignmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var result = await _mediator.Send(new DeleteAssignmentCommand { AssignmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }



    }
}
