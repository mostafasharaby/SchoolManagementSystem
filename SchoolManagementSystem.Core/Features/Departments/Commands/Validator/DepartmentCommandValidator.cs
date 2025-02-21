using FluentValidation;
using SchoolManagementSystem.Core.Features.Departments.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Departments.Commands.Validator
{
    public class DepartmentCommandValidator<T> : AbstractValidator<Department> where T : class
    {
        public DepartmentCommandValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Department Name is required.")
                .MaximumLength(100).WithMessage("Department Name must not exceed 100 characters.");
        }
    }

    public class AddDepartmentCommandValidator : DepartmentCommandValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator() : base() { }
    }

    public class UpdateDepartmentCommandValidator : DepartmentCommandValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(x => x.DepartmentID)
                .GreaterThan(0).WithMessage("Department ID is required and must be a valid positive number.");
        }
    }
}
