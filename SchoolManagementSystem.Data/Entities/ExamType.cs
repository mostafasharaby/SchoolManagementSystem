namespace SchoolManagementSystem.Data.Entities
{
    public class ExamType
    {
        public int ExamTypeID { get; set; } // Primary Key (non-nullable)
        public string? TypeName { get; set; } // e.g., Midterm, Final, Quiz

        // Navigation Properties
        public ICollection<Exam>? Exams { get; set; }
    }

}
