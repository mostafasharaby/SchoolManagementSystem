using FluentValidation;
using SchoolManagementSystem.Core.Features.Fees.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Validators
{
    public class UpdateFeeValidator : AbstractValidator<UpdateFeeCommand>
    {
        public UpdateFeeValidator()
        {
            RuleFor(f => f.FeeID).GreaterThan(0).WithMessage("Invalid Fee ID.");
            RuleFor(f => f.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }
}
