using FluentValidation;
using SchoolManagementSystem.Core.Features.Claims.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Claims.Commands.Validator
{

    public class UserClaimCommandValidator<T> : AbstractValidator<T> where T : AddUserClaimCommand
    {
        public UserClaimCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.Claim)
                .NotNull().WithMessage("Claim details are required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Claim!.Type)
                        .NotEmpty().WithMessage("Claim Type is required.");

                    RuleFor(x => x.Claim!.Value)
                        .NotEmpty().WithMessage("Claim Value is required.");
                });
        }
    }

    public class AddUserClaimCommandValidator : UserClaimCommandValidator<AddUserClaimCommand>
    {
        public AddUserClaimCommandValidator() : base() { }
    }

    public class UpdateUserClaimsCommandValidator : AbstractValidator<UpdateUserClaimsCommand>
    {
        public UpdateUserClaimsCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.Claim)
                .NotNull().WithMessage("Claim details are required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Claim!.Type)
                        .NotEmpty().WithMessage("Claim Type is required.");

                    RuleFor(x => x.Claim!.Value)
                        .NotEmpty().WithMessage("Claim Value is required.");
                });
        }
    }
}
