using FluentValidation;
using SchoolManagementSystem.Core.Features.Enrollments.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Enrollments.Commands.Validator
{
    public class EnrollmentCommandValidator<T> : AbstractValidator<T> where T : EnrollmentDto
    {
        public EnrollmentCommandValidator()
        {
            RuleFor(x => x.StudentID)
                .Empty().WithMessage("Student ID is required ");

            RuleFor(x => x.CourseID)
                .GreaterThan(0).WithMessage("Course ID is required and must be a valid positive number.");

            RuleFor(x => x.EnrollmentDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Enrollment date cannot be in the future.")
                .When(x => x.EnrollmentDate != null);
        }
    }

    public class AddEnrollmentCommandValidator : EnrollmentCommandValidator<AddEnrollmentCommand>
    {
        public AddEnrollmentCommandValidator() : base() { }
    }

    public class UpdateEnrollmentCommandValidator : EnrollmentCommandValidator<UpdateEnrollmentCommand>
    {
        public UpdateEnrollmentCommandValidator()
        {
            RuleFor(x => x.EnrollmentID)
                .GreaterThan(0).WithMessage("Enrollment ID is required and must be a valid positive number.");
        }
    }
}
