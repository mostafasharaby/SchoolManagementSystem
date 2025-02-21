namespace SchoolManagementSystem.Data.Entities
{
    public class ExamResult
    {
        public int ExamResultID { get; set; } // Primary Key (non-nullable)
        public string StudentID { get; set; } // Foreign Key (nullable)
        public int ExamID { get; set; } // Foreign Key (nullable)
        public decimal? Score { get; set; }

        // Navigation Properties
        public Student? Student { get; set; }
        public Exam? Exam { get; set; }
    }

}
