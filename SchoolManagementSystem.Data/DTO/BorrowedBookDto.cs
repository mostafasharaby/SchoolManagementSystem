namespace SchoolManagementSystem.Data.DTO
{
    public class BorrowedBookDto
    {
        public int? StudentID { get; set; }
        public int? LibraryID { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
