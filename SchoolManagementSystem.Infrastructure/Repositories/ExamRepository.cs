using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
        public async override Task<Exam> GetByIdAsync(int id)
        {
            return await _dbContext.Exams.AsNoTracking()
          .FirstOrDefaultAsync(b => b.ExamID == id);
        }
        public async override Task<List<Exam>> GetAllAsync()
        {
            return await _dbContext.Exams.Include(e => e.Course)
                                   .Include(e => e.ExamType)
                                   .ToListAsync();
        }

        public async Task<List<Exam>> GetExamsByCourseAsync(int courseId)
        {
            return await _dbContext.Exams.Where(e => e.CourseID == courseId).ToListAsync();
        }

    }
}
