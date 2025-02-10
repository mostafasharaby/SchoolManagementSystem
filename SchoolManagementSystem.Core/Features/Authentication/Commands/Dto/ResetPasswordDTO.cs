using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Dto
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required, MinLength(6)]
        public string NewPassword { get; set; }
    }
}
