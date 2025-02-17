using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models
{
    public class UpdateBorrowedBookCommand : BorrowedBookDto, IRequest<Response<string>>
    {
        public int BorrowID { get; set; }

    }
}
