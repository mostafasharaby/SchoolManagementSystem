namespace SchoolManagementSystem.Data.Entities
{
    public class ExamScore
    {
        public int ExamScoreID { get; set; }
        public int ExamID { get; set; }
        public string StudentID { get; set; }
        public decimal? Score { get; set; }

        public Exam? Exam { get; set; }
        public Student? Student { get; set; }
    }
}
