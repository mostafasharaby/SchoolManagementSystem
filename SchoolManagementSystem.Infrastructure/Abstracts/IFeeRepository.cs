using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IFeeRepository : IGenericRepository<Fee>
    {
        Task<List<Fee>> GetOutstandingFeesAsync(int studentId);
    }
}
