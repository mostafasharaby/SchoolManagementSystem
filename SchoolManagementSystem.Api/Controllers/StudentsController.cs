using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.AppRouting;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BasicController
    {

        public StudentsController(IMediator _mediator) : base(_mediator) { }


        // GET: api/Students
        [HttpGet("Dto")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsDto()
        {
            var studentDtos = await _mediator.Send(new GetStudentDtoQuery());

            var responseHandler = new ResponseHandler();
            var response = responseHandler.Success(studentDtos);

            return NewResult(response);  // this will return same result that DtoWithStatus 
        }


        // GET: api/Students
        [HttpGet("DtoWithStatus")]
        public async Task<ActionResult<Response<List<StudentDto>>>> GetStudentsDtoWithStatus()
        {
            return await _mediator.Send(new GetStudentDtoQueryWithStatus());
        }


        [HttpGet(Routing.StudentRouting.List)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            //return await _mediator.Send(new GetAllStudentsQuery());
            var studentList = await _mediator.Send(new GetAllStudentsQuery());
            return NewResult(new ResponseHandler().Success(studentList));
        }


        [HttpGet(Routing.StudentRouting.ById)]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));

            if (student == null)
            {
                return NewResult(new ResponseHandler().BadRequest<Student>("Student is Not Exist"));
            }

            return NewResult(new ResponseHandler().Success(student));
        }  //    AddStudentCommandWithResponse



        [HttpPost("WithResponse")]
        public async Task<ActionResult<Response<Student>>> CreateStudentWithResponse([FromBody] AddStudentCommandWithResponse command)
        {
            if (command == null)
            {
                return BadRequest("Student data is required.");
            }

            var result = await _mediator.Send(command);

            if (result == null || result.Data == null)
            {
                //var responseHandler = new ResponseHandler();
                //return StatusCode(500, responseHandler.BadRequest<Student>("Failed to create student."));
                return NewResult(new ResponseHandler().BadRequest<Student>(string.Join(", ", result.Errors)));

            }
            //return Ok(result);
            return CreatedAtAction(nameof(GetStudentById), new { id = result.Data.StudentID }, result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            if (command == null || command.Student == null)
            {
                return BadRequest("Student data is required.");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return StatusCode(500, "Failed to create student.");
            }

            return CreatedAtAction(nameof(GetStudentById), new { id = result.StudentID }, result);
        }



        [HttpPut(Routing.StudentRouting.Update)]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.StudentID)
            {
                return BadRequest("Student ID mismatch.");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                // return NotFound("Student not found.");
                return NewResult(new ResponseHandler().BadRequest<Student>("Student not found ."));
            }
            //return Ok("Student updated successfully.");
            return NewResult(new ResponseHandler().Success(result, "Student Updated Sudccessfully ."));

        }


        [HttpPut("updateWithValidation/{id}")]
        public async Task<IActionResult> UpdateStudentWithValidation(int id, [FromBody] UpdateStudentCommandWithValidation command)
        {
            if (id != command.StudentID)
            {
                return BadRequest("Student ID mismatch.");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                // return NotFound("Student not found.");
                return NewResult(new ResponseHandler().BadRequest<Student>("Student not found ."));
            }
            //return Ok("Student updated successfully.");
            return NewResult(new ResponseHandler().Success(result, "Student Updated Sudccessfully ."));

        }


        // Delete Student
        [HttpDelete(Routing.StudentRouting.Delete)]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));

            if (!result)
            {
                return NotFound("Student not found");
            }

            return Ok(result);
        }
    }
}
