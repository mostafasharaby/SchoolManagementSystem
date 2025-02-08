namespace SchoolManagementSystem.Data.Entities
{
    public class Parent
    {
        public int ParentID { get; set; } // Primary Key (non-nullable)
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        // Navigation Properties
        public ICollection<Student>? Students { get; set; }
    }

}
