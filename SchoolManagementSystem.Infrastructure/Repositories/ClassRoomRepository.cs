using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ClassRoomRepository : GenericRepository<Classroom>, IClassRoomRepository
    {
        private readonly IMapper _mapper;
        public ClassRoomRepository(SchoolContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<Classroom>> GetAllClassroomsAsync()
        {
            return await GetAllAsync();
        }


        public async Task<Classroom> GetClassRoomByIdAsync(int ClassRommId)
        {
            return await GetByIdAsync(ClassRommId);
        }
        public async Task AddClassroomAsync(Classroom Classroom)
        {
            await AddAsync(Classroom);
        }


        public async Task<Classroom> UpdateClassroomAsync(Classroom Classroom)
        {
            await UpdateAsync(Classroom);
            return Classroom;
        }

        public async Task<bool> DeleteClassroomAsync(int classRoomId)
        {
            var room = await GetByIdAsync(classRoomId);
            if (room != null)
            {
                await DeleteAsync(room);
                return true;
            }
            return false;
        }

        public async Task<List<Student>> GetStudentsInClassroomAsync(int classroomId) // will be change to Dto.....
        {
            return await _dbContext.Students
                .Where(s => s.ClassroomID == classroomId)
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendanceRecordsAsync(int classroomId)
        {
            var result = await _dbContext.Attendances
                .Where(a => a.ClassroomID == classroomId)
                .ToListAsync();

            return result;
        }

        public async Task<Teacher> GetTeacherInClassroomAsync(int classroomId) // will be change to Dto.....
        {
            var result = await _dbContext.Classrooms
                .Where(c => c.ClassroomID == classroomId)
                .Select(c => c.Teacher)
                .FirstOrDefaultAsync();

            return result!; //_mapper.Map<Teacher>(result);
        }
    }
}
