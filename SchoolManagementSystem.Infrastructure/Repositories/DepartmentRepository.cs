using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        SchoolContext _dbContext;
        public DepartmentRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<Department> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.AsNoTracking()
          .FirstOrDefaultAsync(b => b.DepartmentID == id);

        }


    }
}
