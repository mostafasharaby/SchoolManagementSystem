using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentBorrowedBooksQuery : IRequest<Response<List<BorrowedBookDto>>>
    {
        public int StudentID { get; set; }
    }
}
