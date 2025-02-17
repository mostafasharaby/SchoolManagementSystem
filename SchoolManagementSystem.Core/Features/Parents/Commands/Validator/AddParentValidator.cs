using FluentValidation;
using SchoolManagementSystem.Core.Features.Parents.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Validator
{
    public class AddParentValidator : AbstractValidator<AddParentCommand>
    {
        public AddParentValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
