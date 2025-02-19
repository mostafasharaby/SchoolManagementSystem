namespace SchoolManagementSystem.Data.Entities
{
    public class ExamType
    {
        public int ExamTypeID { get; set; }
        public string? TypeName { get; set; } // e.g., Midterm, Final, Quiz

        public ICollection<Exam>? Exams { get; set; }
    }

}
