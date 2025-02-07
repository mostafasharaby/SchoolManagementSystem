﻿namespace SchoolManagementSystem.Core.Features.Students.Queries.Results
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmail { get; set; }
        // public int? ClassroomID { get; set; }
        public string? ClassroomName { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? ParentFirstName { get; set; }            // className+PropertyName
    }
}
