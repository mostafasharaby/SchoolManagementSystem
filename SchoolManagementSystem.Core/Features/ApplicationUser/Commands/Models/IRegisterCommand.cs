namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models
{
    public interface IRegisterCommand
    {
        string? UserName { get; set; }
        string? Password { get; set; }
        string? ConfirmPassword { get; set; }
        string? Email { get; set; }
    }
}
