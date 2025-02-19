using FluentValidation;
using SchoolManagementSystem.Core.Features.Exams.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Exams.Commands.Validator
{
    public class ExamCommandValidator<T> : AbstractValidator<T> where T : ExamDto
    {
        public ExamCommandValidator()
        {
            RuleFor(x => x.ExamName)
                .NotEmpty().WithMessage("Exam Name is required.")
                .MaximumLength(100).WithMessage("Exam Name must not exceed 100 characters.");

            RuleFor(x => x.CourseID)
                .GreaterThan(0).WithMessage("Course ID must be a valid positive number.")
                 .When(x => x.Date.HasValue);

            RuleFor(x => x.Date)
                .GreaterThan(DateTime.UtcNow).WithMessage("Exam Date must be in the future.")
                 .When(x => x.Date.HasValue);
        }
    }

    public class AddExamCommandValidator : ExamCommandValidator<AddExamCommand>
    {
        public AddExamCommandValidator() : base() { }
    }

    public class UpdateExamCommandValidator : ExamCommandValidator<UpdateExamCommand>
    {
        public UpdateExamCommandValidator()
        {
            RuleFor(x => x.ExamID)
                .GreaterThan(0).WithMessage("Exam ID is required and must be a valid positive number.");
        }
    }
}
