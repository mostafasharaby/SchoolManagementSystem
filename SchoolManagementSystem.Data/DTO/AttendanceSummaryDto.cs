namespace SchoolManagementSystem.Data.DTO
{
    public class AttendanceSummaryDto
    {
        public int ClassroomID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int TotalStudents { get; set; }
        public int PresentStudents { get; set; }
        public int AbsentStudents { get; set; }
    }
}
