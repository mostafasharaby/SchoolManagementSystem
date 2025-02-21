using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Department> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.AsNoTracking()
          .FirstOrDefaultAsync(b => b.DepartmentID == id);

        }

        public async Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            return await _dbContext.Courses
           .Where(t => t.DepartmentID == departmentId)
           .ToListAsync();
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId)
        {
            return await _dbContext.Teachers
             .Where(c => c.DepartmentID == departmentId)
             .ToListAsync();
        }
    }
}
