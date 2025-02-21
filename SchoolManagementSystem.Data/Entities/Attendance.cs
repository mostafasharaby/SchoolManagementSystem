namespace SchoolManagementSystem.Data.Entities
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public string StudentID { get; set; }
        public int ClassroomID { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; } // e.g., Present, Absent
                                            // public bool? IsPresent { get; set; }
        public Student? Student { get; set; }
        public Classroom? Classroom { get; set; }
    }

}
