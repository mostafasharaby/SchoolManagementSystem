using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models
{
    public class GetAllBorrowedBooksQuery : IRequest<Response<List<BorrowedBookDto>>>
    {
    }
}
