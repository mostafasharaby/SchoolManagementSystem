using FluentValidation;
using SchoolManagementSystem.Core.Features.Attendances.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Validator
{
    public class AttendanceCommandValidator<T> : AbstractValidator<T> where T : AttendanceDto
    {
        public AttendanceCommandValidator()
        {
            RuleFor(x => x.StudentID)
                .GreaterThan(0).WithMessage("Student ID is required and must be a valid positive number.");

            RuleFor(x => x.ClassroomID)
                .GreaterThan(0).WithMessage("Classroom ID is required and must be a valid positive number.");

            RuleFor(x => x.Date)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.")
                .When(x => x.Date.HasValue);

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => status == "Present" || status == "Absent")
                .WithMessage("Status must be either 'Present' or 'Absent'.");
        }
    }

    public class AddAttendanceCommandValidator : AttendanceCommandValidator<AddAttendanceCommand>
    {
        public AddAttendanceCommandValidator() : base() { }
    }

    public class UpdateAttendanceCommandValidator : AttendanceCommandValidator<UpdateAttendanceCommand>
    {
        public UpdateAttendanceCommandValidator()
        {
            RuleFor(x => x.AttendanceID)
                .GreaterThan(0).WithMessage("Attendance ID is required and must be a valid positive number.");
        }
    }
}
