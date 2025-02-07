namespace SchoolManagementSystem.Data.Entities
{
    public class Exam
    {
        public int ExamID { get; set; } // Primary Key
        public string? ExamName { get; set; }
        public int? CourseID { get; set; } // Foreign Key
        public int? ExamTypeID { get; set; } // Foreign Key
        public DateTime? Date { get; set; }
    }
}
