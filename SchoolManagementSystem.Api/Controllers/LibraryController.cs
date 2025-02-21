using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Libraies.Commands.Models;
using SchoolManagementSystem.Core.Features.Libraies.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : BasicController
    {
        public LibraryController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler) { }


        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var result = await _mediator.Send(new GetBookByIDCommand { LibraryID = id });
            return result.Succeeded ? Ok(result) : NotFound(result);

        }
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-book")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("return-book")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-book/{libraryId}")]
        public async Task<IActionResult> DeleteBook(int libraryId)
        {
            var result = await _mediator.Send(new DeleteBookCommand { LibraryID = libraryId });
            return result.Succeeded ? Ok(result) : NotFound(result);

        }
    }
}
