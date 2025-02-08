namespace SchoolManagementSystem.Data.Entities
{
    public class Grade
    {
        public int GradeID { get; set; } // Primary Key (non-nullable)
        public string? GradeName { get; set; }

        // Navigation Properties
        public ICollection<Classroom>? Classrooms { get; set; }
    }
}

