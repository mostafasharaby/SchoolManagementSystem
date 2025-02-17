using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models
{
    public class AddBorrowedBookCommand : BorrowedBookDto, IRequest<Response<string>>
    {
    }
}
