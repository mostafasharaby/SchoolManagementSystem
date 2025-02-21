namespace SchoolManagementSystem.Data.DTO
{
    public class FeePaymentDto
    {
        public int FeePaymentID { get; set; }
        public string? StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
