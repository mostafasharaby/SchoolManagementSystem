using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IParentRepository : IGenericRepository<Parent>
    {
        Task<List<Student>> GetStudentsByParentAsync(int parentId);
        Task<List<Fee>> GetFeePaymentHistoryByParentAsync(int parentId);
    }
}
