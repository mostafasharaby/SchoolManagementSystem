using FluentValidation;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Validator
{
    public class BorrowedBookValidator : AbstractValidator<BorrowedBookDto>
    {
        public BorrowedBookValidator()
        {
            RuleFor(x => x.StudentID).NotNull().WithMessage("StudentID is required.");
            RuleFor(x => x.LibraryID).NotNull().WithMessage("LibraryID is required.");
            RuleFor(x => x.BorrowDate).NotNull().WithMessage("BorrowDate is required.");
        }
    }

}
