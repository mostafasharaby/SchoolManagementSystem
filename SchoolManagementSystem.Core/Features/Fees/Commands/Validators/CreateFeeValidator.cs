using FluentValidation;
using SchoolManagementSystem.Core.Features.Fees.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Validators
{
    public class CreateFeeValidator : AbstractValidator<CreateFeeCommand>
    {
        public CreateFeeValidator()
        {
            RuleFor(f => f.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(f => f.DueDate).NotNull().WithMessage("Due date is required.");
        }
    }
}
