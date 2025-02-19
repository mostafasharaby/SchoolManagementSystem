using FluentValidation;
using SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Validator
{
    public class ExamTypeCommandValidator<T> : AbstractValidator<T> where T : ExamTypeDto
    {
        public ExamTypeCommandValidator()
        {
            RuleFor(x => x.TypeName)
                .NotEmpty().WithMessage("Exam Type Name is required.")
                .MaximumLength(100).WithMessage("Exam Type Name must not exceed 100 characters.");
        }
    }

    public class AddExamTypeCommandValidator : ExamTypeCommandValidator<AddExamTypeCommand>
    {
        public AddExamTypeCommandValidator() : base() { }
    }

    public class UpdateExamTypeCommandValidator : ExamTypeCommandValidator<UpdateExamTypeCommand>
    {
        public UpdateExamTypeCommandValidator()
        {
            RuleFor(x => x.ExamTypeID)
                .GreaterThan(0).WithMessage("Exam Type ID is required and must be a valid positive number.");
        }
    }
}
