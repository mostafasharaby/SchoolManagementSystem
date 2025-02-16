using FluentValidation;
using SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Validators
{
    public class AddClassroomCommandValidator : AbstractValidator<AddClassroomCommand>
    {
        public AddClassroomCommandValidator()
        {
            RuleFor(x => x.ClassroomName)
                .NotEmpty().WithMessage("Classroom name is required")
                .MaximumLength(100).WithMessage("Classroom name must be less than 100 characters");

            RuleFor(x => x.GradeID)
                .GreaterThan(0).WithMessage("GradeID must be greater than 0");

            RuleFor(x => x.TeacherID)
                .GreaterThan(0).WithMessage("TeacherID must be greater than 0");
        }
    }
}
