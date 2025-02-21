using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Libraies.Queries.Models
{
    public class GetAllBorrowedBooksQuery : IRequest<Response<List<BorrowedBookDto>>>
    {
    }
}
