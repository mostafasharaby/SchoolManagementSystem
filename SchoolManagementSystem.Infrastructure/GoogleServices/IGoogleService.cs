using Microsoft.AspNetCore.Authentication;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Infrastructure.GoogleServices
{
    public interface IGoogleService
    {
        AuthenticationProperties GetGoogleLoginProperties(string redirectUri);
        Task<AuthResponse> GoogleLoginCallbackAsync();
    }
}
