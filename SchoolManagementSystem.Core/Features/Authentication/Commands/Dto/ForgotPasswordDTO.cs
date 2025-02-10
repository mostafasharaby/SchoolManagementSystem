using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Dto
{
    public class ForgotPasswordDTO
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
