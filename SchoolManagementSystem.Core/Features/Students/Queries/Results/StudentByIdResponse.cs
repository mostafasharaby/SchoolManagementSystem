namespace SchoolManagementSystem.Core.Features.Students.Queries.Results
{
    public class StudentByIdResponse
    {
        public int ID { get; set; } // Primary Key
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public List<ParentResponse>? ParentResponse { get; set; }
        public List<ClassroomResponse>? ClassroomResponse { get; set; }
    }

    public class ParentResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class ClassroomResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
