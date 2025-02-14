using FluentValidation;
using SchoolManagementSystem.Core.Features.Roles.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Roles.Commands.Validator
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleValidator()
        {
            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role ID is required.");
            RuleFor(x => x.NewRoleName)
                .NotEmpty().WithMessage("New Role Name is required.")
                .MinimumLength(3).WithMessage("New Role Name must be at least 3 characters.");
        }
    }
}
