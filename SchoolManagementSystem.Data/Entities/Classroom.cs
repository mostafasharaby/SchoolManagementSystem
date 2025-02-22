namespace SchoolManagementSystem.Data.Entities
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public string? ClassroomName { get; set; }
        public int GradeID { get; set; }
        public string? TeacherID { get; set; }


        public Grade? Grade { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
    }

}
