using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class CourseRepository : GenericRepository<Course>, ICourseRepository
    {

        SchoolContext _dbContext;
        public CourseRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<Course> GetByIdAsync(int id)
        {
            return await _dbContext.Courses.AsNoTracking()
          .FirstOrDefaultAsync(b => b.CourseID == id);

        }

    }
}
