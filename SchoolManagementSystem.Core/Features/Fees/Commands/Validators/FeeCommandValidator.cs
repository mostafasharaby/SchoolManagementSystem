using FluentValidation;
using SchoolManagementSystem.Core.Features.Fees.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Validators
{
    public class FeeCommandValidator<T> : AbstractValidator<T> where T : FeeDto
    {
        public FeeCommandValidator()
        {
            RuleFor(x => x.StudentID)
                .NotNull().WithMessage("Student ID is required.")
                .GreaterThan(0).WithMessage("Student ID must be a valid positive number.");

            RuleFor(x => x.Amount)
                .NotNull().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(x => x.DueDate)
                .NotNull().WithMessage("Due Date is required.")
                .GreaterThan(DateTime.Now).WithMessage("Due Date must be in the future.");
        }
    }

    public class CreateFeeCommandValidator : FeeCommandValidator<CreateFeeCommand>
    {
        public CreateFeeCommandValidator() : base() { }
    }

    public class PayFeeCommandValidator : FeeCommandValidator<PayFeeCommand>
    {
        public PayFeeCommandValidator()
        {
            RuleFor(x => x.PaidDate)
                .NotNull().WithMessage("Paid Date is required when paying a fee.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Paid Date cannot be in the future.");
        }
    }

    public class UpdateFeeCommandValidator : FeeCommandValidator<UpdateFeeCommand>
    {
        public UpdateFeeCommandValidator()
        {
            RuleFor(x => x.FeeID)
                .GreaterThan(0).WithMessage("Fee ID is required and must be a valid positive number.");
        }
    }
}
