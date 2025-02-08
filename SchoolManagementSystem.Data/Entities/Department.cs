namespace SchoolManagementSystem.Data.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; } // Primary Key (non-nullable)
        public string? DepartmentName { get; set; }

        // Navigation Properties
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
