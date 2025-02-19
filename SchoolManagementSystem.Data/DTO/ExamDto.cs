namespace SchoolManagementSystem.Data.DTO
{
    public class ExamDto
    {
        public string? ExamName { get; set; } = string.Empty;
        public int CourseID { get; set; }
        public int ExamTypeID { get; set; }
        public DateTime? Date { get; set; }
    }

}
