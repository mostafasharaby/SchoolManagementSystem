using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class BorrowedBookRepository : GenericRepository<BorrowedBook>, IBorrowedBookRepository
    {

        public BorrowedBookRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async override Task<BorrowedBook> GetByIdAsync(int id)
        {
            return await _dbContext.BorrowedBooks.AsNoTracking()
          .FirstOrDefaultAsync(b => b.BorrowID == id);

        }
        public async Task<List<BorrowedBook>> GetBorrowedBooksByStudentIdAsync(int studentId)
        {
            return await _dbContext.BorrowedBooks
                .Where(b => b.StudentID == studentId)
                .ToListAsync();
        }
    }
}
