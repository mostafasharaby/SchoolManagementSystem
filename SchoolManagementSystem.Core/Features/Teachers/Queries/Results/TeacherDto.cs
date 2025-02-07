namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Results
{
    public class TeacherDto
    {
        public int TeacherID { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public string? TeacherPhoneNumber { get; set; }
        public string? TeacherEmail { get; set; }
        public int? DepartmentID { get; set; }
        public int? TeacherTypeID { get; set; }
    }
}
