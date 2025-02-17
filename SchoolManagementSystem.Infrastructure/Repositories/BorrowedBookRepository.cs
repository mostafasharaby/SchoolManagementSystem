using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class BorrowedBookRepository : GenericRepository<BorrowedBook>, IBorrowedBookRepository
    {
        SchoolContext _dbContext;
        public BorrowedBookRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BorrowedBook>> GetBorrowedBooksByStudentIdAsync(int studentId)
        {
            return await _dbContext.BorrowedBooks
                .Where(b => b.StudentID == studentId)
                .ToListAsync();
        }
    }
}
