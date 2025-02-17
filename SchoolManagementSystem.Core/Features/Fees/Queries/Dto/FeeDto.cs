﻿namespace SchoolManagementSystem.Core.Features.Fees.Queries.Dto
{
    public class FeeDto
    {
        public int? StudentID { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
