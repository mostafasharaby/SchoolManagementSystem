﻿namespace SchoolManagementSystem.Core.Features.Attendances.Queries.Dto
{
    public class AttendanceDto
    {
        public int? StudentID { get; set; }
        public int? ClassroomID { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
    }
}
