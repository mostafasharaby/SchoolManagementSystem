using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet(Routing.TeacherRouting.List)]
        //public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        //{
        //    return await _mediator.Send(new GetAllTeachersQuery());
        //}

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _mediator.Send(new GetAllTeachersQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetTeacherById(string id)
        {
            var result = await _mediator.Send(new GetTeacherByIdQuery { TeacherID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpGet("by-department/{departmentId}")]
        public async Task<IActionResult> GetTeachersByDepartment(int departmentId)
        {
            var result = await _mediator.Send(new GetTeachersByDepartmentQuery { DepartmentID = departmentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        [HttpGet("{teacherId}/courses")]
        public async Task<IActionResult> GetCoursesByTeacher(string teacherId)
        {
            var result = await _mediator.Send(new GetCoursesByTeacherQuery { TeacherID = teacherId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{teacherId}/classrooms")]
        public async Task<IActionResult> GetClassroomsByTeacher(string teacherId)
        {
            var result = await _mediator.Send(new GetClassroomsByTeacherQuery { TeacherID = teacherId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{teacherId}/classrooms/{classroomId}/students")]
        public async Task<IActionResult> GetStudentsInClassroom(string teacherId, int classroomId)
        {
            var result = await _mediator.Send(new GetStudentsInClassroomQuery { TeacherID = teacherId, ClassroomID = classroomId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{teacherId}/courses/{courseId}/exam-results")]
        public async Task<IActionResult> GetExamResultsByCourse(string teacherId, int courseId)
        {
            var result = await _mediator.Send(new GetExamResultsByCourseQuery { TeacherID = teacherId, CourseID = courseId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }


        //[HttpPost("add")]
        //public async Task<IActionResult> AddTeacher([FromBody] AddTeacherCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return result.Succeeded ? Ok(CreatedAtAction(nameof(AddTeacher), new { id = result.Data }, result)) : BadRequest(result);
        //}

        [HttpPost("add-assignment")]
        public async Task<IActionResult> AddAssignmentToCourse([FromBody] AddAssignmentToCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }


        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadFile([FromForm] UploadFileCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return result.Succeeded ? Ok(result) : BadRequest(result);
        //}


        [HttpPut("update")]
        public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTeacher(string id)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand { TeacherID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }



    }
}
