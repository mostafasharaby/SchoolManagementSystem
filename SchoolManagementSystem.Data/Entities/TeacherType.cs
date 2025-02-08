namespace SchoolManagementSystem.Data.Entities
{
    public class TeacherType
    {
        public int TeacherTypeID { get; set; } // Primary Key (non-nullable)
        public string? TypeName { get; set; } // e.g., Full-time, Part-time

        // Navigation Properties
        public ICollection<Teacher>? Teachers { get; set; }
    }
}
