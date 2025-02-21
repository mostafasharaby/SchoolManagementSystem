namespace SchoolManagementSystem.Data.DTO
{
    public class AttendanceDto
    {
        public string? StudentID { get; set; }
        public int ClassroomID { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
    }
}
