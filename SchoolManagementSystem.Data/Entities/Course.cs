namespace SchoolManagementSystem.Data.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string TeacherID { get; set; }
        public int DepartmentID { get; set; }


        // public Teacher? Teacher { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>(); // new class 

        public Department? Department { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }

}
