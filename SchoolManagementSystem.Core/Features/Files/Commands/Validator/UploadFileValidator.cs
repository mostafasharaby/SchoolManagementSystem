using FluentValidation;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Features.Files.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Files.Commands.Validator
{
    public class UploadFileValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileValidator()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("File is required")
                .Must(BeAValidImage).WithMessage("Invalid file type. Allowed: jpg, png, jpeg");

            RuleFor(x => x.File.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024) // 5MB max
                .WithMessage("File size must be less than 5MB");
        }

        private bool BeAValidImage(IFormFile file)
        {
            if (file == null) return false;
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            return allowedExtensions.Contains(fileExtension);
        }
    }
}
