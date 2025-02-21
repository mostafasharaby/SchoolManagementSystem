using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models
{
    public class AddBorrowedBookCommand : BorrowedBookDto, IRequest<Response<string>>
    {
    }
}
