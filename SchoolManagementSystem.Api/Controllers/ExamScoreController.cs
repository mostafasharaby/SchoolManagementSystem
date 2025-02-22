using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models;
using SchoolManagementSystem.Core.Features.ExamsScore.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamScoreController : BasicController
    {
        public ExamScoreController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAllExamScores()
        {
            var result = await _mediator.Send(new GetExamScoresQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetExamScoreById(int id)
        {
            var result = await _mediator.Send(new GetExamScoreByIdQuery { ExamScoreID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("exam/{examId}")]
        public async Task<IActionResult> GetExamScoresByExam(int examId)
        {
            var result = await _mediator.Send(new GetExamScoresByExamQuery { ExamID = examId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetExamScoresByStudent(string studentId)
        {
            var result = await _mediator.Send(new GetExamScoresByStudentQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddExamScore([FromBody] AddExamScoreCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Created("", result) : BadRequest(result);
        }

        [HttpPut("update{id}")]
        public async Task<IActionResult> UpdateExamScore(int id, [FromBody] UpdateExamScoreCommand command)
        {
            if (id != command.ExamScoreID)
                return NewResult<string>(new Response<string>("ID mismatch"));

            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExamScore(int id)
        {
            var result = await _mediator.Send(new DeleteExamScoreCommand { ExamScoreID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

    }
}
