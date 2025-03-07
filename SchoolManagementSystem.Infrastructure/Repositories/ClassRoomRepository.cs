using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ClassRoomRepository : GenericRepository<Classroom>, IClassRoomRepository
    {

        public ClassRoomRepository(SchoolContext context) : base(context)
        {
        }

        // will be change to Dto.....
        public async Task<List<Student>> GetStudentsInClassroomAsync(int classroomId) =>
            await _dbContext.Students
                .Where(s => s.ClassroomID == classroomId)
                .ToListAsync();

        public async Task<List<Attendance>> GetAttendanceRecordsAsync(int classroomId) =>
            await _dbContext.Attendances
                .Where(a => a.ClassroomID == classroomId)
                .ToListAsync();

        public async Task<Teacher> GetTeacherInClassroomAsync(int classroomId) =>
            await _dbContext.Classrooms
                .Where(c => c.ClassroomID == classroomId)!
                .Select(c => c.Teacher)
                .FirstOrDefaultAsync();
    }
}
