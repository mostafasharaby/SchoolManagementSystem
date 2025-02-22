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
                .Empty().WithMessage("Student ID is required ");

            RuleFor(x => x.StudentFirstNameEn)
                .NotEmpty().WithMessage("Student first name is required.")
                .MaximumLength(50).WithMessage("Student first name must be at most 50 characters.");

            RuleFor(x => x.StudentLastNameEn)
                .NotEmpty().WithMessage("Student last name is required.")
                .MaximumLength(50).WithMessage("Student last name must be at most 50 characters.");

            RuleFor(x => x.StudentFirstNameAr)
                .NotEmpty().WithMessage("الاسم الاول مطلوب")
                .MaximumLength(50).WithMessage("الاسم الاول لا يتخطي ال 50 حرفا");

            RuleFor(x => x.StudentLastNameAr)
                .NotEmpty().WithMessage("الاسم الاخير مطلوب")
                .MaximumLength(50).WithMessage("الاسم الاخير لا يتخطي ال 50 حرفا");

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
