namespace SchoolManagementSystem.Data.Entities
{
    public class Assignment
    {
        public int AssignmentID { get; set; } // Primary Key (non-nullable)
        public string? AssignmentName { get; set; }
        public int? CourseID { get; set; } // Foreign Key (nullable)
        public DateTime? DueDate { get; set; }

        // Navigation Properties
        public Course? Course { get; set; }
    }

}
