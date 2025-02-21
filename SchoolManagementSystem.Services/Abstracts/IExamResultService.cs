using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IExamResultService
    {
        Task AddExamResultAsync(ExamResult examResult);
        Task UpdateExamResultAsync(ExamResult examResult);
        Task<bool> DeleteExamResultAsync(int examResultID);
        Task<ExamResult> GetExamResultByIdAsync(int examResultID);
        Task<List<ExamResult>> GetExamResultsByExamAsync(int examID);
        Task<List<ExamResult>> GetExamResultsByStudentAsync(int studentID);
        Task<List<ExamResult>> GetAllExamResultsAsync();
    }
}
