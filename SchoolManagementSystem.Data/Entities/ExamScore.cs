namespace SchoolManagementSystem.Data.Entities
{
    public class ExamScore
    {
        public int ExamScoreID { get; set; } // Primary Key (non-nullable)
        public int ExamID { get; set; } // Foreign Key (nullable)
        public int StudentID { get; set; } // Foreign Key (nullable)
        public decimal? Score { get; set; }

        // Navigation Properties
        public Exam? Exam { get; set; }
        public Student? Student { get; set; }
    }
}
