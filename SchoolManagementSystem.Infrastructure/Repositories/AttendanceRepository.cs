using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        private readonly SchoolContext _dbContext;
        public AttendanceRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Attendance> GetByIdAsync(int id)
        {
            return await _dbContext.Attendances.AsNoTracking()
          .FirstOrDefaultAsync(b => b.AttendanceID == id);
        }
    }
}
