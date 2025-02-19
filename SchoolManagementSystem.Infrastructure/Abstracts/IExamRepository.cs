using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<List<Exam>> GetExamsByCourseAsync(int courseId);
    }
}
