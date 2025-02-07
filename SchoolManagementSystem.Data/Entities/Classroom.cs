namespace SchoolManagementSystem.Data.Entities
{
    public class Classroom
    {
        public int ClassroomID { get; set; } // Primary Key
        public string? ClassroomName { get; set; }
        public int? GradeID { get; set; } // Foreign Key
        public int? TeacherID { get; set; } // Foreign Key

        public Teacher? Teacher { get; set; }
    }
}
