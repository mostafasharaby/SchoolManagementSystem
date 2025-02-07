namespace SchoolManagementSystem.Data.Entities
{
    public class Assignment
    {
        public int AssignmentID { get; set; } // Primary Key
        public string? AssignmentName { get; set; }
        public int? CourseID { get; set; } // Foreign Key
        public DateTime? DueDate { get; set; }
    }
}
