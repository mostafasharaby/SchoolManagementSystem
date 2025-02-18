using FluentValidation;
using SchoolManagementSystem.Core.Features.Courses.Commands.Models;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Commands.Validator
{
    public class CourseCommandValidator<T> : AbstractValidator<T> where T : CourseDto
    {
        public CourseCommandValidator()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Course Name is required.")
                .MaximumLength(100).WithMessage("Course Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.TeacherID)
                .GreaterThan(0).WithMessage("Teacher ID must be a valid positive number.");

            RuleFor(x => x.DepartmentID)
                .GreaterThan(0).WithMessage("Department ID must be a valid positive number.");
        }
    }

    public class AddCourseCommandValidator : CourseCommandValidator<AddCourseCommand>
    {
        public AddCourseCommandValidator() : base() { }
    }

    public class UpdateCourseCommandValidator : CourseCommandValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.CourseID)
                .GreaterThan(0).WithMessage("Course ID is required and must be a valid positive number.");
        }
    }
}
