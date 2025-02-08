namespace SchoolManagementSystem.Data.Entities
{
    public class StudentClassroom
    {
        public int StudentClassroomID { get; set; } // Primary Key (non-nullable)
        public int? StudentID { get; set; } // Foreign Key (nullable)
        public int? ClassroomID { get; set; } // Foreign Key (nullable)
        public DateTime? EnrollmentDate { get; set; }

        // Navigation Properties
        public Student? Student { get; set; }
        public Classroom? Classroom { get; set; }
    }

}
