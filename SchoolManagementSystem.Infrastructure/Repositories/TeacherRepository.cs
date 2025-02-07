using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.Infrastructure.RepositoryImpelementation
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly SchoolContext _context;

        public TeacherRepository(SchoolContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            return await GetByIdAsync(teacherId);
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            AddAsync(teacher);
        }

        public async Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            await UpdateAsync(teacher);
            return teacher;
        }

        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            var teacher = await GetByIdAsync(teacherId);
            if (teacher == null) return false;

            if (teacher != null)
            {
                await DeleteAsync(teacher);
                return true;
            }
            return false;

        }


    }
}
