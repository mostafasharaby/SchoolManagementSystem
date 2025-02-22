namespace SchoolManagementSystem.Data.DTO
{
    public class TeacherDto
    {
        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public DateTime? TeacherDateOfBirth { get; set; }
        public string? TeacherGender { get; set; }
        public string? TeacherAddress { get; set; }
        public string? TeacherPhoneNumber { get; set; }
        public int DepartmentID { get; set; }
        public int? TeacherTypeID { get; set; }
    }
}
