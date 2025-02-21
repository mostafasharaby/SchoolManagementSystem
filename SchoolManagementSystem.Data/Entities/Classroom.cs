namespace SchoolManagementSystem.Data.Entities
{
    public class Classroom
    {
        public int ClassroomID { get; set; } // Primary Key (non-nullable)
        public string? ClassroomName { get; set; }
        public int GradeID { get; set; } // Foreign Key (nullable)
        public string TeacherID { get; set; } // Foreign Key (nullable)

        // Navigation Properties
        public Grade? Grade { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
    }

}
