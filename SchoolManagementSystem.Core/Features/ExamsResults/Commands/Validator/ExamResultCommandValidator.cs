using FluentValidation;
using SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Commands.Validator
{
    public class ExamResultCommandValidator<T> : AbstractValidator<T> where T : ExamResultDto
    {
        public ExamResultCommandValidator()
        {
            RuleFor(x => x.StudentID)
                .Empty().WithMessage("Student ID must be valid.");

            RuleFor(x => x.ExamID)
                .GreaterThan(0).WithMessage("Exam ID must be a valid positive number.");

            RuleFor(x => x.Score)
                .InclusiveBetween(0, 100).WithMessage("Score must be between 0 and 100.");
        }
    }

    public class AddExamResultCommandValidator : ExamResultCommandValidator<AddExamResultCommand>
    {
        public AddExamResultCommandValidator() : base() { }
    }

    public class UpdateExamResultCommandValidator : ExamResultCommandValidator<UpdateExamResultCommand>
    {
        public UpdateExamResultCommandValidator()
        {
            RuleFor(x => x.ExamResultID)
                .GreaterThan(0).WithMessage("Exam Result ID is required and must be a valid positive number.");
        }
    }

    public class DeleteExamResultCommandValidator : AbstractValidator<DeleteExamResultCommand>
    {
        public DeleteExamResultCommandValidator()
        {
            RuleFor(x => x.ExamResultID)
                .GreaterThan(0).WithMessage("Exam Result ID must be a valid positive number.");
        }
    }
}
