namespace SchoolManagementSystem.Data.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; } // Primary Key
        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public DateTime? TeacherDateOfBirth { get; set; }
        public string? TeacherGender { get; set; }
        public string? TeacherAddress { get; set; }
        public string? TeacherPhoneNumber { get; set; }
        public string? TeacherEmail { get; set; }
        public int? DepartmentID { get; set; } // Foreign Key
        public int? TeacherTypeID { get; set; } // Foreign Key
    }
}
