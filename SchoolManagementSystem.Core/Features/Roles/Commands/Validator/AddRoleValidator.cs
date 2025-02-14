using FluentValidation;
using SchoolManagementSystem.Core.Features.Roles.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Validator
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Role name is required.")
                .MinimumLength(3).WithMessage("Role name must be at least 3 characters long.");
        }
    }

}
