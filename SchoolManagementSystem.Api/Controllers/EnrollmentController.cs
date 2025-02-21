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


        [HttpGet("all")]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var result = await _mediator.Send(new GetAllEnrollmentsQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var result = await _mediator.Send(new GetEnrollmentByIdQuery { EnrollmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetEnrollmentsByCourseId(int courseId)
        {
            var result = await _mediator.Send(new GetEnrollmentsByCourseIdQuery { CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEnrollment([FromBody] AddEnrollmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEnrollment([FromBody] UpdateEnrollmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var result = await _mediator.Send(new DeleteEnrollmentCommand { EnrollmentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }



    }
}
