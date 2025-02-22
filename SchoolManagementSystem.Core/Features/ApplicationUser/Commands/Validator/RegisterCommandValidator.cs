using FluentValidation;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;

public class RegisterCommandValidator<T> : AbstractValidator<T> where T : IRegisterCommand
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
}

public class RegisterStudentCommandValidator : RegisterCommandValidator<RegisterStudentCommand>
{
    public RegisterStudentCommandValidator()
    {
        RuleFor(x => x.StudentFirstNameAr)
            .NotEmpty().WithMessage("Student first name (Arabic) is required.");

        RuleFor(x => x.StudentFirstNameEn)
            .NotEmpty().WithMessage("Student first name (English) is required.");

        RuleFor(x => x.StudentLastNameAr)
            .NotEmpty().WithMessage("Student last name (Arabic) is required.");

        RuleFor(x => x.StudentLastNameEn)
            .NotEmpty().WithMessage("Student last name (English) is required.");

        RuleFor(x => x.StudentDateOfBirth)
            .NotNull().WithMessage("Date of birth is required.")
            .LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.StudentGender)
            .NotEmpty().WithMessage("Gender is required.");

        RuleFor(x => x.ClassroomID)
            .GreaterThan(0).WithMessage("Classroom ID must be a valid positive number.");

        RuleFor(x => x.ParentID)
            .GreaterThan(0).WithMessage("Parent ID must be a valid positive number.");
    }
}

public class RegisterTeacherCommandValidator : RegisterCommandValidator<RegisterTeacherCommand>
{
    public RegisterTeacherCommandValidator()
    {
        RuleFor(x => x.TeacherFirstName)
            .NotEmpty().WithMessage("Teacher first name is required.");

        RuleFor(x => x.TeacherLastName)
            .NotEmpty().WithMessage("Teacher last name is required.");

        RuleFor(x => x.TeacherDateOfBirth)
            .NotNull().WithMessage("Date of birth is required.")
            .LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.TeacherGender)
            .NotEmpty().WithMessage("Gender is required.");

        RuleFor(x => x.DepartmentID)
            .GreaterThan(0).WithMessage("Department ID must be a valid positive number.");

        RuleFor(x => x.TeacherTypeID)
            .GreaterThan(0).WithMessage("Teacher Type ID must be a valid positive number.")
            .When(x => x.TeacherTypeID.HasValue);
    }
}