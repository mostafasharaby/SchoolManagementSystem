namespace SchoolManagementSystem.Core.Features.Students.Queries.Results
{
    public class StudentDtoForAdd
    {
        public int StudentID { get; set; }
        public string? StudentFirstNameAr { get; set; }
        public string? StudentFirstNameEn { get; set; }

        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmail { get; set; }
        // public int? ClassroomID { get; set; }
        public string? ClassroomName { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? ParentFirstName { get; set; }            // className+PropertyName
    }
}
