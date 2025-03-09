namespace SchoolManagementSystem.Data.DTO
{
    public class BorrowedBookDto
    {
        public string? StudentID { get; set; }
        public int? LibraryID { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

    //public record BorrowedBookDto2(string? StudentID, int? LibraryID, DateTime? BorrowDate, DateTime? ReturnDate)
    //{
    //    public BorrowedBookDto2() : this(null, null, null, null)
    //    {
    //    }
    //}
    public record BorrowedBookDto2(string? StudentID = null, int? LibraryID = null, DateTime? BorrowDate = null, DateTime? ReturnDate = null);

}
