using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ParentRepository : GenericRepository<Parent>, IParentRepository
    {
        public ParentRepository(SchoolContext context) : base(context)
        {
        }

        public async Task<List<Parent>> GetAllStudentsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Parent> GetStudentByIdAsync(int ParentId)
        {
            return await GetByIdAsync(ParentId);
        }
        public async Task<Parent> GetStudentByNameAsync(string name)
        {
            return await GetByNameAsync(name);
        }
        public async Task AddStudentAsync(Parent student)
        {
            await AddAsync(student);
        }

        public async Task<Parent> UpdateStudentAsync(Parent student)
        {
            await UpdateAsync(student);
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int ParentId)
        {
            var student = await GetByIdAsync(ParentId);
            if (student != null)
            {
                await DeleteAsync(student);
                return true;
            }
            return false;
        }

    }
}
