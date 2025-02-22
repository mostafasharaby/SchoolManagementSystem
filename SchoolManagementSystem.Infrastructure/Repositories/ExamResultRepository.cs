using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class ExamResultRepository : GenericRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
        public async override Task<ExamResult> GetByIdAsync(int id)
        {
            return await _dbContext.ExamResults.AsNoTracking()
          .FirstOrDefaultAsync(b => b.ExamResultID == id);
        }


        public async Task<List<ExamResult>> GetExamResultsByExamAsync(int examID)
        {
            return await _dbContext.ExamResults
            .Where(er => er.ExamID == examID)
            .ToListAsync();
        }

        public async Task<List<ExamResult>> GetExamResultsByStudentAsync(string studentID)
        {
            return await _dbContext.ExamResults
           .Where(er => er.StudentID == studentID)
           .ToListAsync();
        }
    }
}
