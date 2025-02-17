using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models
{
    public class GetBorrowedBooksByStudentQuery : IRequest<Response<List<BorrowedBookDto>>>
    {
        public int StudentID { get; set; }
    }
}
