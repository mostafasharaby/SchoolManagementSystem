using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IExamResultRepository : IGenericRepository<ExamResult>
    {
        Task<List<ExamResult>> GetExamResultsByExamAsync(int examID);
        Task<List<ExamResult>> GetExamResultsByStudentAsync(int studentID);

    }
}
