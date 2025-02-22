using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IExamScoreRepository : IGenericRepository<ExamScore>
    {
        Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId);
        Task<List<ExamScore>> GetExamScoresByStudentIdAsync(string studentId);
    }
}
