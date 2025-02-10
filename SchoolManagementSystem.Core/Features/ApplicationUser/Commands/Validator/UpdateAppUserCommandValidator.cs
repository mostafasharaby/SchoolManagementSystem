using FluentValidation;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Validator
{
    public class UpdateAppUserCommandValidator : AbstractValidator<UpdateAppUserCommand>
    {
        public UpdateAppUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(50).WithMessage("UserName must be at most 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");
        }
    }
}
