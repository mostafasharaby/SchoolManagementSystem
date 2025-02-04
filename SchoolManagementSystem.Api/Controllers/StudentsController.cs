using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Students
        [HttpGet("Dto")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsDto()
        {
            return await _mediator.Send(new GetStudentDtoQuery());
        }

        // GET: api/Students
        [HttpGet("DtoWithStatus")]
        public async Task<ActionResult<Response<List<StudentDto>>>> GetStudentsDtoWithStatus()
        {
            return await _mediator.Send(new GetStudentDtoQueryWithStatus());
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.StudentID)
            {
                return BadRequest("Student ID mismatch.");
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Student not found.");
            }

            return Ok("Student updated successfully.");
        }

        // Delete Student
        [HttpDelete("{id}")]
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
