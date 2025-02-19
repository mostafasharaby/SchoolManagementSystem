using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ParentRepository : GenericRepository<Parent>, IParentRepository
    {
        public ParentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Fee>> GetFeePaymentHistoryByParentAsync(int parentId)
        {
            return await _dbContext.Fees
           .Where(fp => fp.Student.ParentID == parentId)
           .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByParentAsync(int parentId)
        {
            return await _dbContext.Students
            .Where(s => s.ParentID == parentId)
            .ToListAsync();
        }
    }
}
