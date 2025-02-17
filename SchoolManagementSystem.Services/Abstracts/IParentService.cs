using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{

    public interface IParentService
    {
        Task AddParentAsync(Parent Parent);
        Task UpdateParentsAsync(Parent Parent);
        Task<bool> DeleteParentsAsync(int ParentID);
        Task<Parent> GetParentsByIdAsync(int ParentID);
        Task<List<Parent>> GetAllParentsAsync();
    }
}
