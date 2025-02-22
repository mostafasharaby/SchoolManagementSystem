using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models
{
    public class GetBorrowedBooksByStudentQuery : IRequest<Response<List<BorrowedBookDto>>>
    {
        public string? StudentID { get; set; }
    }
}
