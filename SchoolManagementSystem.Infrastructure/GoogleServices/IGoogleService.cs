using Microsoft.AspNetCore.Authentication;

namespace SchoolManagementSystem.Infrastructure.GoogleServices
{
    public interface IGoogleService
    {
        AuthenticationProperties GetGoogleLoginProperties(string redirectUri);
        Task<string> GoogleLoginCallbackAsync();
    }
}
