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

        public async Task<List<Classroom>> GetAllStudentsAsync()
        {
            return await GetAllAsync();
        }


        public async Task<Classroom> GetClassRoomByIdAsync(int ClassRommId)
        {
            return await GetByIdAsync(ClassRommId);
        }
        public async Task AddStudentAsync(Classroom Classroom)
        {
            await AddAsync(Classroom);
        }


        public async Task<Classroom> UpdateStudentAsync(Classroom Classroom)
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

    }
}
