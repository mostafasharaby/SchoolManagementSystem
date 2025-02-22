using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IBorrowedBookService
    {
        Task AddBorrowedBookAsync(BorrowedBook borrowedBook);
        Task<bool> UpdateBorrowedBookAsync(BorrowedBook borrowedBook);
        Task<bool> DeleteBorrowedBookAsync(int borrowedBookId);
        Task<BorrowedBook> GetBorrowedBookByIdAsync(int BorrowedBookId);
        Task<List<BorrowedBook>> GetAllBorrowedBooksAsync();
        Task<List<BorrowedBook>> GetBorrowedBooksByStudentIdAsync(string studentId);

    }
}
