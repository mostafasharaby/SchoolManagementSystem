using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models;
using SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : BasicController
    {
        public ClassRoomsController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler)
        {
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllClassrooms()
        {
            var result = await _mediator.Send(new GetAllClassroomsQuery());
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetClassroomById(int id)
        {
            var result = await _mediator.Send(new GetClassroomByIdQuery { ClassroomID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpGet("{classroomId}/students")]
        public async Task<IActionResult> GetStudentsInClassroom(int classroomId)
        {
            var result = await _mediator.Send(new GetClassroomStudentsQuery { ClassroomId = classroomId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{classroomId}/attendance")]
        public async Task<IActionResult> GetClassroomAttendance(int classroomId)
        {
            var result = await _mediator.Send(new GetClassroomAttendanceQuery { ClassroomId = classroomId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{classroomId}/teacher")]
        public async Task<IActionResult> GetClassroomTeacher(int classroomId)
        {
            var result = await _mediator.Send(new GetClassroomTeacherQuery { ClassroomId = classroomId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddClassroom([FromBody] AddClassroomCommand command)
        {
            var classroomId = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddClassroom), new { id = classroomId }, new { Id = classroomId });
        }

        [HttpPost("add-with-students")]
        public async Task<IActionResult> AddClassroomWithStudents([FromBody] AddClassroomWithStudentsCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClassroom([FromBody] UpdateClassroomCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var result = await _mediator.Send(new DeleteClassroomCommand { ClassroomID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }






    }
}
