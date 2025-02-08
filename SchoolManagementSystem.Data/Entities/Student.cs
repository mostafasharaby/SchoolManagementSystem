using SchoolManagementSystem.Data.General;

namespace SchoolManagementSystem.Data.Entities
{
    public class Student : LocalizedEntityGeneral
    {
        public int StudentID { get; set; } // Primary Key
        public string? StudentFirstNameEn { get; set; }
        public string? StudentLastNameEn { get; set; }
        public string? StudentFirstNameAr { get; set; }
        public string? StudentLastNameAr { get; set; }
        public DateTime? StudentDateOfBirth { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmail { get; set; }
        public int? ParentID { get; set; } // Foreign Key
        public int? ClassroomID { get; set; } // Foreign Key

        public Parent? Parent { get; set; }
        public Classroom? Classroom { get; set; }

        public List<Parent>? ParentList { get; set; }
        public List<Classroom>? ClassroomLsit { get; set; }

    }
}
