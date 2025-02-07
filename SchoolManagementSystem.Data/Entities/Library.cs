namespace SchoolManagementSystem.Data.Entities
{
    public class Library
    {
        public int LibraryID { get; set; } // Primary Key
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int? Quantity { get; set; }
    }
}
