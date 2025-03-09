using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models
{
    //public class GetBorrowedBookByIdQuery : IRequest<Response<BorrowedBookDto>>
    //{
    //    public int BorrowedBookId { get; set; }
    //}
    public record GetBorrowedBookByIdQuery(int BorrowedBookId) : IRequest<Response<BorrowedBookDto2>>;
}
