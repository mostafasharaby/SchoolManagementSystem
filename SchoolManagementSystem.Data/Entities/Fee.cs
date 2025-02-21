namespace SchoolManagementSystem.Data.Entities
{
    public class Fee
    {
        public int FeeID { get; set; } // Primary Key (non-nullable)
        public int StudentID { get; set; } // Foreign Key (nullable)
        public decimal? Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; } // Nullable

        // Navigation Properties
        public Student? Student { get; set; }
    }
}
