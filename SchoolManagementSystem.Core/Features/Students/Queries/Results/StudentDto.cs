namespace SchoolManagementSystem.Core.Features.Students.Queries.Results
{
    public class StudentDto
    {
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public string? ClassroomName { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? ParentFirstName { get; set; }            // className+PropertyName
    }
}
