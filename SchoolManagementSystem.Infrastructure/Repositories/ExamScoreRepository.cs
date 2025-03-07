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
        public async override Task<ExamScore> GetByIdAsync(int id) =>
            await _dbContext.ExamScores.AsNoTracking()
            .FirstOrDefaultAsync(b => b.ExamScoreID == id);

        public async Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId) =>
            await _dbContext.ExamScores
            .Where(er => er.ExamID == examId)
            .ToListAsync();

        public async Task<List<ExamScore>> GetExamScoresByStudentIdAsync(string studentId) =>
            await _dbContext.ExamScores
            .Where(er => er.StudentID == studentId)
            .ToListAsync();

    }
}
