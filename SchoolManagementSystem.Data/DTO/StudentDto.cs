namespace SchoolManagementSystem.Data.DTO
{
    public class Student_Teacher_ClassRomm_Parent_Dto
    {
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public string? ClassroomName { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? ParentFirstName { get; set; }            // className+PropertyName
    }

    public class StudentDto
    {
        public string? StudentFirstNameAr { get; set; }
        public string? StudentFirstNameEn { get; set; }
        public string? StudentLastNameAr { get; set; }
        public string? StudentLastNameEn { get; set; }
        public DateTime? StudentDateOfBirth { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmail { get; set; }
        public string? Image { get; set; }
        public int ParentID { get; set; }
        public int? ClassroomID { get; set; }
    }
}
