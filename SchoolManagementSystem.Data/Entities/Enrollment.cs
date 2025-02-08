namespace SchoolManagementSystem.Data.Entities
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; } // Primary Key (non-nullable)
        public int? StudentID { get; set; } // Foreign Key (nullable)
        public int? CourseID { get; set; } // Foreign Key (nullable)
        public DateTime? EnrollmentDate { get; set; }

        // Navigation Properties
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
