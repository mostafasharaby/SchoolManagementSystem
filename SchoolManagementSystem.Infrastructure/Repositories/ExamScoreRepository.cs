using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ExamScoreRepository : GenericRepository<ExamScore>, IExamScoreRepository
    {
        public ExamScoreRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
        public async override Task<ExamScore> GetByIdAsync(int id)
        {
            return await _dbContext.ExamScores.AsNoTracking()
          .FirstOrDefaultAsync(b => b.ExamScoreID == id);
        }
        public async Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId)
        {
            var scores = await _dbContext.ExamScores.Where(s => s.ExamID == examId).ToListAsync();
            return scores;
        }

        public async Task<List<ExamScore>> GetExamScoresByStudentIdAsync(string studentId)
        {
            var scores = await _dbContext.ExamScores.Where(s => s.StudentID == studentId).ToListAsync();
            return scores;
        }


    }
}
