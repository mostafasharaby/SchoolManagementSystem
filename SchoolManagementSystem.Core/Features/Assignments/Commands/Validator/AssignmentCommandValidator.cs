using FluentValidation;
using SchoolManagementSystem.Core.Features.Assignments.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Assignments.Commands.Validator
{
    public class AssignmentCommandValidator<T> : AbstractValidator<T> where T : AssignmentDto
    {
        public AssignmentCommandValidator()
        {
            RuleFor(x => x.AssignmentName)
                .NotEmpty().WithMessage("Assignment Name is required.")
                .MaximumLength(100).WithMessage("Assignment Name must not exceed 100 characters.");

            RuleFor(x => x.CourseID)
                .GreaterThan(0).WithMessage("Course ID must be a valid positive number.")
                .When(x => x.CourseID.HasValue);

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("Due Date must be in the future.")
                .When(x => x.DueDate.HasValue);
        }
    }

    public class AddAssignmentCommandValidator : AssignmentCommandValidator<AddAssignmentCommand>
    {
        public AddAssignmentCommandValidator() : base() { }
    }

    public class UpdateAssignmentCommandValidator : AssignmentCommandValidator<UpdateAssignmentCommand>
    {
        public UpdateAssignmentCommandValidator()
        {
            RuleFor(x => x.AssignmentID)
                .GreaterThan(0).WithMessage("Assignment ID is required and must be a valid positive number.");
        }
    }
}
