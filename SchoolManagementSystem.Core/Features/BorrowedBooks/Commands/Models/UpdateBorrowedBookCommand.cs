using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models
{
    public class UpdateBorrowedBookCommand : BorrowedBookDto, IRequest<Response<string>>
    {
        public int BorrowID { get; set; }

    }
}
