namespace SchoolManagementSystem.Data.Responses
{
    public class UserRoles
    {
        public string? UserId { get; set; }
        public List<RolesDetails>? RolesDetails { get; set; }
    }
    public class RolesDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

    }
}
