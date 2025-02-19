using FluentValidation;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Validator
{
    public class TeacherCommandValidator<T> : AbstractValidator<T> where T : TeacherDto
    {
        public TeacherCommandValidator()
        {
            RuleFor(x => x.TeacherFirstName)
                .NotEmpty().WithMessage("Teacher First Name is required.")
                .MaximumLength(50).WithMessage("Teacher First Name must not exceed 50 characters.");

            RuleFor(x => x.TeacherLastName)
                .NotEmpty().WithMessage("Teacher Last Name is required.")
                .MaximumLength(50).WithMessage("Teacher Last Name must not exceed 50 characters.");

            RuleFor(x => x.TeacherDateOfBirth)
                .LessThan(DateTime.UtcNow).WithMessage("Date of Birth must be in the past.");

            RuleFor(x => x.TeacherEmail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.DepartmentID)
                .GreaterThan(0).WithMessage("Department ID must be a valid positive number.")
                .When(x => x.DepartmentID.HasValue);
        }
    }

    public class AddTeacherCommandValidator : TeacherCommandValidator<AddTeacherCommand>
    {
        public AddTeacherCommandValidator() : base() { }
    }

    public class UpdateTeacherCommandValidator : TeacherCommandValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(x => x.TeacherID)
                .GreaterThan(0).WithMessage("Teacher ID is required and must be a valid positive number.");
        }
    }
}
