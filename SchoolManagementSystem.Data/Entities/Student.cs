using SchoolManagementSystem.Data.General;

namespace SchoolManagementSystem.Data.Entities
{
    public class Student : LocalizedEntityGeneral
    {
        public int StudentID { get; set; } // Primary Key (non-nullable)
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

        public int? ParentID { get; set; } // Foreign Key (nullable)
        public int? ClassroomID { get; set; } // Foreign Key (nullable)

        // Navigation Properties
        public Parent? Parent { get; set; }
        public Classroom? Classroom { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
        public ICollection<BorrowedBook>? BorrowedBooks { get; set; }
        public ICollection<Fee>? Fees { get; set; }
    }



}
