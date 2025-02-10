using FluentValidation;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Validator
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("كلمة المرور الحالية مطلوبة.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("كلمة المرور الجديدة مطلوبة.")
                .MinimumLength(8).WithMessage("يجب أن تكون كلمة المرور الجديدة 8 أحرف على الأقل.")
                .Matches("[A-Z]").WithMessage("يجب أن تحتوي كلمة المرور على حرف كبير واحد على الأقل.")
                .Matches("[a-z]").WithMessage("يجب أن تحتوي كلمة المرور على حرف صغير واحد على الأقل.")
                .Matches("[0-9]").WithMessage("يجب أن تحتوي كلمة المرور على رقم واحد على الأقل.")
                .Matches("[^a-zA-Z0-9]").WithMessage("يجب أن تحتوي كلمة المرور على رمز خاص واحد على الأقل.");

            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty().WithMessage("تأكيد كلمة المرور مطلوب.")
                .Equal(x => x.NewPassword).WithMessage("يجب أن تتطابق كلمات المرور.");
        }
    }
}
