using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IBorrowedBookRepository : IGenericRepository<BorrowedBook>
    {
        Task<List<BorrowedBook>> GetBorrowedBooksByStudentIdAsync(string studentId);
    }
}
