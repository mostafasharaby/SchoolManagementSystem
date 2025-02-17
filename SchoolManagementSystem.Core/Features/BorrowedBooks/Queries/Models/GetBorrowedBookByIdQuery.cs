using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models
{
    public class GetBorrowedBookByIdQuery : IRequest<Response<BorrowedBookDto>>
    {
        public int BorrowedBookId { get; set; }
    }
}
