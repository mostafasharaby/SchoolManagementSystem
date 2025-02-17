using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models
{
    public class DeleteBorrowedBookCommand : IRequest<Response<string>>
    {
        public int BorrowID { get; set; }
    }
}
