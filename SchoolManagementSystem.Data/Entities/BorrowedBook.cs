namespace SchoolManagementSystem.Data.Entities
{
    public class BorrowedBook
    {
        public int BorrowID { get; set; } // Primary Key (non-nullable)
        public int StudentID { get; set; } // Foreign Key (nullable)
        public int LibraryID { get; set; } // Foreign Key (nullable)
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable

        // Navigation Properties
        public Student? Student { get; set; }
        public Library? Library { get; set; }
    }
}
