using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.AppRouting;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Filter;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]

    // [Authorize(Roles = "student")]
    [ApiController]
    public class StudentsController : BasicController
    {

        public StudentsController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }


        // GET: api/Students
        [HttpGet("Dto")]

        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsDto()
        {
            var studentDtos = await _mediator.Send(new GetStudentDtoQuery());
            var response = _responseHandler.Success(studentDtos);
            response.Meta = response.Data.Count();
            return NewResult(response);  // this will return same result that DtoWithStatus 
        }


        // GET: api/Students GetStudentsPaginatedQuery 
        [Authorize(Policy = "PermissionPolicy")]
        [Authorize(Policy = "EmailPolicy")]
        [HttpGet("DtoWithStatus")]
        public async Task<ActionResult<Response<List<StudentDto>>>> GetStudentsDtoWithStatus()
        {
            return await _mediator.Send(new GetStudentDtoQueryWithStatus());
        }

        [ServiceFilter(typeof(AuthFilter))]
        [HttpGet("ListWithPagination")]
        public async Task<ActionResult<List<Student>>> GetStudentsWithPagination([FromQuery] GetStudentsPaginatedQuery studentsPaginatedQuery)
        {
            var studentPagination = await _mediator.Send(studentsPaginatedQuery);
            var response = _responseHandler.Success(studentPagination);
            response.Meta = response.Data.Data.Count();
            return NewResult(response);

            // return NewResult(_responseHandler.Success(_mediator.Send()));
        }

        [Authorize(Roles = "student")]
        [ServiceFilter(typeof(AuthFilter))]
        [HttpGet(Routing.StudentRouting.List)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            //return await _mediator.Send(new GetAllStudentsQuery());
            var studentList = await _mediator.Send(new GetAllStudentsQuery());
            return NewResult(_responseHandler.Success(studentList));
        }


        [HttpGet(Routing.StudentRouting.ById)]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));

            if (student == null)
            {
                return NewResult(_responseHandler.BadRequest<Student>(""));
            }

            return NewResult(_responseHandler.Success(student));
        }


        [HttpGet("WithResponse/{id}")]
        public async Task<ActionResult<Student>> GetStudentByIdResponse(int id)
        {
            var student = await _mediator.Send(new StudentByIdResponseQuery(id));

            if (student == null)
            {
                return NewResult(_responseHandler.NotFound<Student>(""));
            }

            return NewResult(_responseHandler.Success(student));
        }



        [HttpPost("WithResponse")]
        public async Task<ActionResult<Response<Student>>> CreateStudentWithResponse([FromForm] AddStudentCommandWithResponse command)
        {
            if (command == null)
            {
                return BadRequest("");
            }

            var result = await _mediator.Send(command);

            if (result == null || result.Data == null)
            {
                //var responseHandler = _responseHandler;
                //return StatusCode(500, responseHandler.BadRequest<Student>("Failed to create student."));
                return NewResult(_responseHandler.BadRequest<Student>(string.Join(", ", result.Errors)));

            }
            //return Ok(result);
            return CreatedAtAction(nameof(GetStudentById), new { id = result.Data.StudentID }, result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            if (command == null || command.Student == null)
            {
                return BadRequest("");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return StatusCode(500, "");
            }

            return CreatedAtAction(nameof(GetStudentById), new { id = result.StudentID }, result);
        }



        [HttpPut(Routing.StudentRouting.Update)]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.StudentID)
            {
                return BadRequest("");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                // return NotFound("Student not found.");
                return NewResult(_responseHandler.BadRequest<Student>(""));
            }
            //return Ok("Student updated successfully.");
            return NewResult(_responseHandler.Success(result, ""));

        }


        [HttpPut("updateWithValidation/{id}")]
        public async Task<IActionResult> UpdateStudentWithValidation(int id, [FromBody] UpdateStudentCommandWithValidation command)
        {
            if (id != command.StudentID)
            {
                return BadRequest("");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                // return NotFound("Student not found.");
                return NewResult(_responseHandler.BadRequest<Student>());
            }
            //return Ok("Student updated successfully.");
            return NewResult(_responseHandler.Success(result, ""));

        }


        // Delete Student
        [HttpDelete(Routing.StudentRouting.Delete)]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));

            if (!result)
            {
                return NewResult(_responseHandler.BadRequest<Student>());
            }

            return Ok(result);
        }
    }
}
