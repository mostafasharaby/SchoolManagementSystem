namespace SchoolManagementSystem.Data.Entities
{
    public class Attendance
    {
        public int AttendanceID { get; set; } // Primary Key (non-nullable)
        public int? StudentID { get; set; } // Foreign Key (nullable)
        public int? ClassroomID { get; set; } // Foreign Key (nullable)
        public DateTime? Date { get; set; }
        public string? Status { get; set; } // e.g., Present, Absent

        // Navigation Properties
        public Student? Student { get; set; }
        public Classroom? Classroom { get; set; }
    }

}
