namespace SchoolManagementSystem.Data.Entities
{
    public class Library
    {
        public int LibraryID { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int? Quantity { get; set; }
        public ICollection<BorrowedBook>? BorrowedBooks { get; set; }  /// added
    }
}
