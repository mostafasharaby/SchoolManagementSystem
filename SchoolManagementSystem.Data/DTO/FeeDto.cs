namespace SchoolManagementSystem.Data.DTO;
public class FeeDto
{
    public string? StudentID { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? PaidDate { get; set; }
}

