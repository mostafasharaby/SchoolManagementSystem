using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class ExamTypeRepository : GenericRepository<ExamType>, IExamTypeRepository
    {
        public ExamTypeRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async override Task<ExamType> GetByIdAsync(int id)
        {
            return await _dbContext.ExamTypes.AsNoTracking()
          .FirstOrDefaultAsync(b => b.ExamTypeID == id);
        }

    }
}
