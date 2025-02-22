using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Filter;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]

    // [Authorize(Roles = "student")]
    [ApiController]
    public class StudentsController : BasicController
    {

        public StudentsController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }


        // GET: api/Students
        //[HttpGet("Dto")]

        //[Authorize(Roles = "admin")]
        //public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsDto()
        //{
        //    var studentDtos = await _mediator.Send(new GetStudentDtoQuery());
        //    var response = _responseHandler.Success(studentDtos);
        //    response.Meta = response.Data.Count();
        //    return NewResult(response);  // this will return same result that DtoWithStatus 
        //}


        //// GET: api/Students GetStudentsPaginatedQuery 
        //[Authorize(Policy = "PermissionPolicy")]
        //[Authorize(Policy = "EmailPolicy")]
        //[HttpGet("DtoWithStatus")]
        //public async Task<ActionResult<Response<List<StudentDto>>>> GetStudentsDtoWithStatus()
        //{
        //    return await _mediator.Send(new GetStudentDtoQueryWithStatus());
        //}

        //[ServiceFilter(typeof(AuthFilter))]
        //[HttpGet("ListWithPagination")]
        //public async Task<ActionResult<List<Student>>> GetStudentsWithPagination([FromQuery] GetStudentsPaginatedQuery studentsPaginatedQuery)
        //{
        //    var studentPagination = await _mediator.Send(studentsPaginatedQuery);
        //    var response = _responseHandler.Success(studentPagination);
        //    response.Meta = response.Data.Data.Count();
        //    return NewResult(response);

        //    // return NewResult(_responseHandler.Success(_mediator.Send()));
        //}

        //[Authorize(Roles = "student")]
        //[ServiceFilter(typeof(AuthFilter))]
        //[HttpGet(Routing.StudentRouting.List)]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        //{
        //    //return await _mediator.Send(new GetAllStudentsQuery());
        //    var studentList = await _mediator.Send(new GetAllStudentsQuery());
        //    return NewResult(_responseHandler.Success(studentList));
        //}


        //[HttpGet(Routing.StudentRouting.ById)]
        //public async Task<ActionResult<Student>> GetStudentById(int id)
        //{
        //    var student = await _mediator.Send(new GetStudentByIdQuery(id));

        //    if (student == null)
        //    {
        //        return NewResult(_responseHandler.BadRequest<Student>(""));
        //    }

        //    return NewResult(_responseHandler.Success(student));
        //}


        [HttpGet("all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _mediator.Send(new GetAllStudentsQuery());
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery { StudentID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [ServiceFilter(typeof(AuthFilter))]
        [HttpGet("ListWithPagination")]
        public async Task<IActionResult> GetStudentsWithPagination([FromQuery] GetStudentsPaginatedQuery studentsPaginatedQuery)
        {
            var studentPagination = await _mediator.Send(studentsPaginatedQuery);
            var response = _responseHandler.Success(studentPagination);
            response.Meta = response.Data.Data.Count();
            return NewResult(response);
        }

        [HttpGet("{studentId}/courses")]
        public async Task<IActionResult> GetStudentCourses(string studentId)
        {
            var result = await _mediator.Send(new GetStudentCoursesQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{studentId}/attendance")]
        public async Task<IActionResult> GetStudentAttendance(string studentId)
        {
            var result = await _mediator.Send(new GetStudentAttendanceQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{studentId}/exam-results")]
        public async Task<IActionResult> GetStudentExamResults(string studentId)
        {
            var result = await _mediator.Send(new GetStudentExamResultsQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("{studentId}/fee-history")]
        public async Task<IActionResult> GetStudentFeeHistory(string studentId)
        {
            var result = await _mediator.Send(new GetStudentFeeHistoryQuery { StudentID = studentId });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        //[HttpPost("register/student")]
        //public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return result.Succeeded ? Ok(result) : BadRequest(result);
        //}

        [HttpPost("{studentId}/enroll")]
        public async Task<IActionResult> EnrollStudentInCourse(string studentId, [FromBody] int courseId)
        {
            var result = await _mediator.Send(new EnrollStudentInCourseCommand { StudentID = studentId, CourseID = courseId });
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand { StudentID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);
        }
    }
}
