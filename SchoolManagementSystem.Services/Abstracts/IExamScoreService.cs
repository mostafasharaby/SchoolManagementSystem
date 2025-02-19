using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IExamScoreService
    {
        Task<List<ExamScore>> GetAllExamScoresAsync();
        Task<ExamScore?> GetExamScoreByIdAsync(int id);
        Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId);
        Task<List<ExamScore>> GetExamScoresByStudentIdAsync(int studentId);
        Task<bool> AddExamScoreAsync(ExamScore ExamScore);
        Task<bool> UpdateExamScoreAsync(ExamScore ExamScore);
        Task<bool> DeleteExamScoreAsync(int id);
    }

}
