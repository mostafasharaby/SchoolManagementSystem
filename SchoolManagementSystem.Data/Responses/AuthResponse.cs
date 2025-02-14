namespace SchoolManagementSystem.Data.Responses
{
    public class AuthResponse
    {
        public string? Token { get; set; } // JWT or any authentication token
        public DateTime? TokenExpiryTime { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? UserName { get; set; }
        public string? Message { get; set; } // Success or failure message       
        public bool? IsAuthenticated { get; set; } // Indicates if authentication succeeded
    }

}

