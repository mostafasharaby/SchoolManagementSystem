using FluentValidation;
using SchoolManagementSystem.Core.Features.Parents.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Validator
{
    public class ParentCommandValidator<T> : AbstractValidator<T> where T : ParentDto
    {
        public ParentCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }

    public class AddParentCommandValidator : ParentCommandValidator<AddParentCommand>
    {
        public AddParentCommandValidator() : base() { }
    }

    public class UpdateParentCommandValidator : ParentCommandValidator<UpdateParentCommand>
    {
        public UpdateParentCommandValidator()
        {
            RuleFor(x => x.ParentID)
                .GreaterThan(0).WithMessage("Parent ID is required and must be a valid positive number.");
        }
    }
}
