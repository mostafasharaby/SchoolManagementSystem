using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IFeeService
    {
        Task AddFeesAsync(Fee Fees);
        Task<Fee> GetFeesByIdAsync(int FeesId);
        Task<List<Fee>> GetAllFeessAsync();
        Task UpdatelFeesAsync(Fee Fee);
        Task<bool> DeletelFeesAsync(int FeesId);
        Task<List<Fee>> GetOutstandingFeesAsync(int studentId);

    }
}
