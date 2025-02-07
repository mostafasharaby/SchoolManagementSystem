namespace SchoolManagementSystem.Data.Entities
{
    public class Course
    {
        public int CourseID { get; set; } // Primary Key
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int? TeacherID { get; set; } // Foreign Key
        public int? DepartmentID { get; set; } // Foreign Key
    }
}
