using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models;
using SchoolManagementSystem.Core.Features.ExamsResults.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : BasicController
    {
        public ExamResultController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExamResults()
        {
            var result = await _mediator.Send(new GetAllExamResultsQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetExamResultById(int id)
        {
            var result = await _mediator.Send(new GetExamResultByIdQuery { ExamResultID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/exam/{examId}")]
        public async Task<IActionResult> GetExamResultsByExam(int examId)
        {
            var result = await _mediator.Send(new GetExamResultsByExamQuery { ExamID = examId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/student-exams/{studentId}")]
        public async Task<IActionResult> GetExamResultsByStudent(string studentId)
        {
            var result = await _mediator.Send(new GetExamResultsByStudentQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddExamResult([FromBody] AddExamResultCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(CreatedAtAction(nameof(GetExamResultById), new { id = result.Data }, result)) : BadRequest(result);
            //  return CreatedAtAction(nameof(GetExamResultById), new { id = result.Data }, result);
        }

        [HttpPut("update{id}")]
        public async Task<IActionResult> UpdateExamResult(int id, [FromBody] UpdateExamResultCommand command)
        {
            if (id != command.ExamResultID)
                return NewResult<string>(new Response<string>("ID mismatch"));

            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExamResult(int id)
        {
            var result = await _mediator.Send(new DeleteExamResultCommand { ExamResultID = id });
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
