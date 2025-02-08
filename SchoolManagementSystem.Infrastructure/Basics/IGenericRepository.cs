using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Infrastructure.Basics
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        public Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> GetByNameAsync(string name);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task<T> UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        string Exsitance(string message);

    }

}
