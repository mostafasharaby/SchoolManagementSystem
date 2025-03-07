using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task AddRangeAsync(List<Attendance> attendances) =>
            await _dbContext.Attendances.AddRangeAsync(attendances);

        public async Task<List<Attendance>> GetByClassroomAsync(int classroomId) =>
            await _dbContext.Attendances
                .Where(a => a.ClassroomID == classroomId)
                .ToListAsync();

        public async override Task<Attendance> GetByIdAsync(int id) =>
            await _dbContext.Attendances.AsNoTracking().FirstOrDefaultAsync(b => b.AttendanceID == id);
    }
}
