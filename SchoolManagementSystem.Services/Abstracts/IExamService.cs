using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IExamService
    {
        Task AddExamAsync(Exam exam);
        Task<bool> UpdateExamAsync(Exam exam);
        Task<bool> DeleteExamAsync(int examId);
        Task<Exam?> GetExamByIdAsync(int examId);
        Task<List<Exam>> GetAllExamsAsync();
        Task<List<Exam>> GetExamsByCourseAsync(int courseId);
    }
}
