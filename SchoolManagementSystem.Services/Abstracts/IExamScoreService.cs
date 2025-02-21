using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IExamScoreService
    {
        Task<List<ExamScore>> GetAllExamScoresAsync();
        Task<ExamScore?> GetExamScoreByIdAsync(int id);
        Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId);
        Task<List<ExamScore>> GetExamScoresByStudentIdAsync(int studentId);
        Task AddExamScoreAsync(ExamScore ExamScore);
        Task UpdateExamScoreAsync(ExamScore ExamScore);
        Task<bool> DeleteExamScoreAsync(int id);
    }

}
