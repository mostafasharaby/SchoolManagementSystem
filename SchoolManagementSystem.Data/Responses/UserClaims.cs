namespace SchoolManagementSystem.Data.Responses
{
    public class UserClaims
    {
        public string? UserId { get; set; }
        public List<ClaimDetails>? ClaimsDetails { get; set; }
    }

    public class ClaimDetails
    {
        public string? Type { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
