namespace SchoolManagementSystem.Data.Entities
{
    public class Course
    {
        public int CourseID { get; set; } // Primary Key (non-nullable)
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int? TeacherID { get; set; } // Foreign Key (nullable)
        public int? DepartmentID { get; set; } // Foreign Key (nullable)

        // Navigation Properties
        public Teacher? Teacher { get; set; }
        public Department? Department { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }

}
