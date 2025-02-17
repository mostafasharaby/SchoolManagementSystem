using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Controllers.Basics;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBooksController : BasicController
    {
        public BorrowedBooksController(IMediator _mediator, ResponseHandler _responseHandler) : base(_mediator, _responseHandler)
        {
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBorrowedBook([FromBody] AddBorrowedBookCommand command)
        {
            var borrowedBookId = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddBorrowedBook), new { id = borrowedBookId }, new { Id = borrowedBookId });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBorrowedBook([FromBody] UpdateBorrowedBookCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBorrowedBook(int id)
        {
            var result = await _mediator.Send(new DeleteBorrowedBookCommand { BorrowID = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetBorrowedBookById(int id)
        {
            var result = await _mediator.Send(new GetBorrowedBookByIdQuery { BorrowedBookId = id });
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBorrowedBooks()
        {
            var result = await _mediator.Send(new GetAllBorrowedBooksQuery());
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("by-student/{studentId}")]
        public async Task<IActionResult> GetBorrowedBooksByStudent(int studentId)
        {
            var query = new GetBorrowedBooksByStudentQuery { StudentID = studentId };
            var result = await _mediator.Send(query);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
