using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
        public async override Task<Enrollment> GetByIdAsync(int id) =>
            await _dbContext.Enrollments.AsNoTracking()
            .FirstOrDefaultAsync(b => b.EnrollmentID == id);

        public async Task<List<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId) =>
            await _dbContext.Enrollments
            .Where(e => e.CourseID == courseId)
            .ToListAsync();

    }
}
