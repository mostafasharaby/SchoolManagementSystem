﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagementSystem.Infrastructure.Data;
using Serilog;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Infrastructure.Basics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly SchoolContext _dbContext;
        public GenericRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByIdStringAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByNameAsync(string name)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            //  await _dbContext.SaveChangesAsync();          // i will use unit of work here 

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            //  await _dbContext.SaveChangesAsync();         // i will use unit of work here 
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            // await _dbContext.SaveChangesAsync();         // i will use unit of work here 
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                Log.Error($"{typeof(T).Name} with ID {id} not found.");
                return false;
            }

            _dbContext.Set<T>().Remove(entity);
            return true;
        }

        public async Task<bool> DeleteByIdStringAsync(string id)
        {
            var entity = await GetByIdStringAsync(id);
            if (entity == null)
            {
                Log.Error($"{typeof(T).Name} with ID {id} not found.");
                return false;
            }

            _dbContext.Set<T>().Remove(entity);
            return true;
        }


        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public string Exsitance(string message)
        {
            return message;
        }
        public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);
        }


    }

}
