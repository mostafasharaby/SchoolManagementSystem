using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models
{
    //public class UpdateBorrowedBookCommand : BorrowedBookDto, IRequest<Response<string>>
    //{
    //    public int BorrowID { get; set; }

    //}

    public record UpdateBorrowedBookCommand : BorrowedBookDto2, IRequest<Response<string>>
    {
        public int BorrowID { get; init; }
    }
}
