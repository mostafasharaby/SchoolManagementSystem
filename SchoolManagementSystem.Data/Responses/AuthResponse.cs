namespace SchoolManagementSystem.Data.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; } // JWT or any authentication token
        public string UserName { get; set; }
        public string RefreshToken { get; set; } // Optional: Refresh token for re-authentication
        public string Message { get; set; } // Success or failure message
        public bool IsAuthenticated { get; set; } // Indicates if authentication succeeded
    }

}
