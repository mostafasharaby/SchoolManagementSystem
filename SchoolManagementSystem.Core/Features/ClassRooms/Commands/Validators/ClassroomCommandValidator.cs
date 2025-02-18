using FluentValidation;
using SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Validators
{
    public class ClassroomCommandValidator<T> : AbstractValidator<T> where T : ClassroomDto
    {
        public ClassroomCommandValidator()
        {
            RuleFor(x => x.ClassroomName)
                .NotEmpty().WithMessage("Classroom Name is required.")
                .MaximumLength(100).WithMessage("Classroom Name must not exceed 100 characters.");

            RuleFor(x => x.GradeID)
                .NotNull().WithMessage("Grade ID is required.")
                .GreaterThan(0).WithMessage("Grade ID must be a valid positive number.");

            RuleFor(x => x.TeacherID)
                .NotNull().WithMessage("Teacher ID is required.")
                .GreaterThan(0).WithMessage("Teacher ID must be a valid positive number.");
        }
    }

    public class AddClassroomCommandValidator : ClassroomCommandValidator<AddClassroomCommand>
    {
        public AddClassroomCommandValidator() : base() { }
    }

    public class UpdateClassroomCommandValidator : ClassroomCommandValidator<UpdateClassroomCommand>
    {
        public UpdateClassroomCommandValidator()
        {
            RuleFor(x => x.ClassroomID)
                .GreaterThan(0).WithMessage("Classroom ID is required and must be a valid positive number.");
        }
    }

    public class AddClassroomWithStudentsCommandValidator : ClassroomCommandValidator<AddClassroomWithStudentsCommand>
    {
        public AddClassroomWithStudentsCommandValidator() : base() { }
    }
}
