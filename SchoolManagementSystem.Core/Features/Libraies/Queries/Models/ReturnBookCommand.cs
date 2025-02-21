using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Libraies.Queries.Models
{
    public class ReturnBookCommand : IRequest<Response<string>>
    {
        public int StudentID { get; set; }
        public int BorrowID { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
