using FluentValidation;
using SchoolManagementSystem.Core.Features.Libraies.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Libraies.Commands.Validator
{
    public class LibraryCommandValidator<T> : AbstractValidator<T> where T : LibraryDto
    {
        public LibraryCommandValidator()
        {
            RuleFor(x => x.BookTitle)
                .NotEmpty().WithMessage("Book Title is required.")
                .MaximumLength(200).WithMessage("Book Title must not exceed 200 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(100).WithMessage("Author name must not exceed 100 characters.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN is required.")
                .Length(13).WithMessage("ISBN must be exactly 13 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be a positive number.");
        }
    }

    public class AddLibraryCommandValidator : LibraryCommandValidator<AddBookCommand>
    {
        public AddLibraryCommandValidator() : base() { }
    }


    public class UpdateLibraryCommandValidator : LibraryCommandValidator<UpdateBookCommand>
    {
        public UpdateLibraryCommandValidator()
        {
            RuleFor(x => x.LibraryID)
                .GreaterThan(0).WithMessage("Library ID is required and must be a valid positive number.");
        }
    }
}
