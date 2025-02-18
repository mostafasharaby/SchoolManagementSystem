using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        SchoolContext _dbContext;
        public EnrollmentRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Enrollment> GetByIdAsync(int id)
        {
            return await _dbContext.Enrollments.AsNoTracking()
          .FirstOrDefaultAsync(b => b.EnrollmentID == id);
        }

    }
}
