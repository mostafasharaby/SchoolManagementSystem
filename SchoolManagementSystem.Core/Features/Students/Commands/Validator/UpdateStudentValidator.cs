using FluentValidation;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validator
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommandWithValidation>
    {
        public UpdateStudentValidator()
        {
            ApplyValidation();
        }

        public void ApplyValidation()
        {
            RuleFor(x => x.StudentID)
                .GreaterThan(0).WithMessage("Student ID is required and must be greater than zero.");

            RuleFor(x => x.StudentFirstName)
                .NotEmpty().WithMessage("Student first name is required.")
                .MaximumLength(50).WithMessage("Student first name must be at most 50 characters.");

            RuleFor(x => x.StudentLastName)
                .NotEmpty().WithMessage("Student last name is required.")
                .MaximumLength(50).WithMessage("Student last name must be at most 50 characters.");

            RuleFor(x => x.StudentGender)
                .NotEmpty().WithMessage("Student gender is required.")
                .Must(gender => gender == "Male" || gender == "Female")
                .WithMessage("Student gender must be 'Male' or 'Female'.");

            RuleFor(x => x.StudentAddress)
                .NotEmpty().WithMessage("Student address is required.")
                .MaximumLength(100).WithMessage("Student address must be at most 100 characters.");

            RuleFor(x => x.ParentIDDD)
                .GreaterThan(0).WithMessage("Parent ID must be greater than zero.")
                .When(x => x.ParentIDDD.HasValue);

            RuleFor(x => x.ClassroomIDDD)
                .GreaterThan(0).WithMessage("Classroom ID must be greater than zero.")
                .When(x => x.ClassroomIDDD.HasValue);
        }
    }
}
