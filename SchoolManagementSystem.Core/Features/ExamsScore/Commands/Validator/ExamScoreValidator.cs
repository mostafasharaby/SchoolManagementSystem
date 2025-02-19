namespace SchoolManagementSystem.Core.Features.ExamsScore.Commands.Validator
{
    using FluentValidation;
    using SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models;
    using SchoolManagementSystem.Data.DTO;

    public class ExamScoreValidator<T> : AbstractValidator<T> where T : ExamScoreDto
    {
        public ExamScoreValidator()
        {
            RuleFor(x => x.ExamID)
                .GreaterThan(0).WithMessage("Exam ID must be valid.");

            RuleFor(x => x.StudentID)
                .GreaterThan(0).WithMessage("Student ID must be valid.");

            RuleFor(x => x.Score)
                .InclusiveBetween(0, 100).WithMessage("Score must be between 0 and 100.");
        }
    }

    public class AddExamScoreValidator : ExamScoreValidator<AddExamScoreCommand> { }

    public class UpdateExamScoreValidator : ExamScoreValidator<UpdateExamScoreCommand>
    {
        public UpdateExamScoreValidator()
        {
            RuleFor(x => x.ExamScoreID)
                .GreaterThan(0).WithMessage("ExamScore ID is required.");
        }
    }

}
