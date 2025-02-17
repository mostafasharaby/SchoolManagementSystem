using SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.BorrowedBookMapping
{
    public partial class BorrowedBoodProfile
    {
        public void AddBorrowedBoodCommandMapping()
        {
            CreateMap<AddBorrowedBookCommand, BorrowedBook>();
            CreateMap<UpdateBorrowedBookCommand, BorrowedBook>();
        }
    }
}
