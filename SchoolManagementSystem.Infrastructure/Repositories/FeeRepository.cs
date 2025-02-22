using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class FeeRepository : GenericRepository<Fee>, IFeeRepository
    {
        public FeeRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Fee>> GetOutstandingFeesAsync(string studentId)
        {
            return await _dbContext.Fees
            .Where(f => f.StudentID == studentId)//  && !f.IsPaid) will be add soon
            .ToListAsync();

        }
    }
}
