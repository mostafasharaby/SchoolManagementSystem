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


        [HttpGet("all")]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _mediator.Send(new GetAllCoursesQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await _mediator.Send(new GetCourseByIdQuery { CourseID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpGet("by-department/{departmentId}")]
        public async Task<IActionResult> GetCoursesByDepartment(int departmentId)
        {
            var query = new GetCoursesByDepartmentQuery { DepartmentID = departmentId };
            var result = await _mediator.Send(query);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{courseId}/students")]
        public async Task<IActionResult> GetStudentsInCourse(int courseId)
        {
            var result = await _mediator.Send(new GetStudentsInCourseQuery { CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{courseId}/assignments")]
        public async Task<IActionResult> GetAssignmentsForCourse(int courseId)
        {
            var result = await _mediator.Send(new GetAssignmentsForCourseQuery { CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{courseId}/exams")]
        public async Task<IActionResult> GetExamsForCourse(int courseId)
        {
            var result = await _mediator.Send(new GetExamsForCourseQuery { CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _mediator.Send(new DeleteCourseCommand { CourseID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


    }
}
