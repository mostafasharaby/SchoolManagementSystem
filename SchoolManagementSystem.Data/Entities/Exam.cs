namespace SchoolManagementSystem.Data.Entities
{
    public class Exam
    {
        public int ExamID { get; set; } // Primary Key (non-nullable)
        public string? ExamName { get; set; }
        public int? CourseID { get; set; } // Foreign Key (nullable)
        public int? ExamTypeID { get; set; } // Foreign Key (nullable)
        public DateTime? Date { get; set; }

        // Navigation Properties
        public Course? Course { get; set; }
        public ExamType? ExamType { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}
