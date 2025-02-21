using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Data.Entities
{
    public class Teacher : AppUser
    {
        //   public int TeacherID { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public DateTime? TeacherDateOfBirth { get; set; }
        public string? TeacherGender { get; set; }
        public string? TeacherAddress { get; set; }
        public string? TeacherPhoneNumber { get; set; }
        public string? TeacherEmail { get; set; }
        public int DepartmentID { get; set; }
        public int TeacherTypeID { get; set; }
        public Department? Department { get; set; }
        public TeacherType? TeacherType { get; set; }
        //public ICollection<Course>? Courses { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>(); // instead of ICollection<Course>
        public ICollection<Classroom>? Classrooms { get; set; }
    }

}
