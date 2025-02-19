using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Exams.Commands.Models;
using SchoolManagementSystem.Core.Features.Exams.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : BasicController
    {
        public ExamController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExams()
        {
            var result = await _mediator.Send(new GetAllExamsQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("by-course/{courseId}")]
        public async Task<IActionResult> GetExamsByCourse(int courseId)
        {
            var result = await _mediator.Send(new GetExamsByCourseQuery { CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);

        }


        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var result = await _mediator.Send(new GetExamByIdQuery { ExamID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddExam([FromBody] AddExamCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update{id}")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] UpdateExamCommand command)
        {
            if (id != command.ExamID)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result); ;
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _mediator.Send(new DeleteExamCommand { ExamID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }




    }
}
