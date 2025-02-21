using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models
{
    public class GetAllBorrowedBooksQuery : IRequest<Response<List<BorrowedBookDto>>>
    {
    }
}
