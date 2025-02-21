using FluentValidation;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Validator
{
    public class BorrowedBookCommandValidator<T> : AbstractValidator<T> where T : BorrowedBookDto
    {
        public BorrowedBookCommandValidator()
        {
            RuleFor(x => x.StudentID)
                .NotNull().WithMessage("Student ID is required.")
                .GreaterThan(0).WithMessage("Student ID must be a valid positive number.");

            RuleFor(x => x.LibraryID)
                .NotNull().WithMessage("Library ID is required.")
                .GreaterThan(0).WithMessage("Library ID must be a valid positive number.");

            RuleFor(x => x.BorrowDate)
                .NotNull().WithMessage("Borrow Date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Borrow Date cannot be in the future.");

            RuleFor(x => x.ReturnDate)
                .GreaterThan(x => x.BorrowDate)
                .WithMessage("Return Date must be after Borrow Date.")
                .When(x => x.ReturnDate.HasValue);
        }
    }

    public class AddBorrowedBookCommandValidator : BorrowedBookCommandValidator<AddBorrowedBookCommand>
    {
        public AddBorrowedBookCommandValidator() : base() { }
    }

    public class UpdateBorrowedBookCommandValidator : BorrowedBookCommandValidator<UpdateBorrowedBookCommand>
    {
        public UpdateBorrowedBookCommandValidator()
        {
            RuleFor(x => x.BorrowID)
                .GreaterThan(0).WithMessage("Borrow ID is required and must be a valid positive number.");
        }
    }
}
