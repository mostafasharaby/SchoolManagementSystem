using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Courses.Commands.Models;
using SchoolManagementSystem.Core.Features.Courses.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BasicController
    {
        public CourseController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpPost("add")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _mediator.Send(new DeleteCourseCommand { CourseID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await _mediator.Send(new GetCourseByIdQuery { CourseID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _mediator.Send(new GetAllCoursesQuery());
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("by-department/{departmentId}")]
        public async Task<IActionResult> GetCoursesByDepartment(int departmentId)
        {
            var query = new GetCoursesByDepartmentQuery { DepartmentID = departmentId };
            var result = await _mediator.Send(query);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
