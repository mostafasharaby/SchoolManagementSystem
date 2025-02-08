using FluentValidation;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validator
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommandWithResponse>
    {
        private readonly IClassRoomRepository _ClassRoomRepository;
        private readonly IParentRepository _ParentRepository;
        public AddStudentValidator(IClassRoomRepository ClassRoomRepository, IParentRepository ParentRepository)
        {
            _ClassRoomRepository = ClassRoomRepository;
            _ParentRepository = ParentRepository;
            ApplyValidation();
        }
        public void ApplyValidation()
        {
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
            .NotNull().WithMessage("الرقم القومي للاب مطلوب")
            .GreaterThan(0).WithMessage("Parent ID must be greater than zero.")
            .MustAsync(async (parentId, cancellation) =>
            {
                return parentId.HasValue && await _ParentRepository.ExistsAsync<Parent>(i => i.ParentID == parentId);
            }).WithMessage("Parent ID does not exist.");


            RuleFor(x => x.ClassroomIDDD)
                .NotNull().WithMessage("رقم الصف مطلوب")
                .GreaterThan(0).WithMessage("Classroom ID must be greater than zero.")
                .MustAsync(async (classroomId, cancellation) =>
                {
                    return classroomId.HasValue && await _ClassRoomRepository.ExistsAsync<Classroom>(i => i.ClassroomID == classroomId);
                }).WithMessage("Classroom ID does not exist.");
        }
    }
}
