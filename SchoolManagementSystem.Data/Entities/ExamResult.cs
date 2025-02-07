namespace SchoolManagementSystem.Data.Entities
{
    public class ExamResult
    {
        public int ExamResultID { get; set; } // Primary Key
        public int? StudentID { get; set; } // Foreign Key
        public int? ExamID { get; set; } // Foreign Key
        public decimal? Score { get; set; }
    }
}
