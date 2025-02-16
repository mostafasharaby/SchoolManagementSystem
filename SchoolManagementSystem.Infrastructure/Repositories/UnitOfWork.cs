using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public SchoolContext _context;
        public IClassRoomRepository Classrooms { get; }

        public IStudentRepository Students { get; }

        //    IClassRoomRepository IUnitOfWork.Classrooms => throw new NotImplementedException();

        public UnitOfWork(SchoolContext context, IClassRoomRepository ClassRoomRepository)
        {
            _context = context;
            Classrooms = ClassRoomRepository;
        }

        public async Task<bool> ExecuteTransactionAsync(Func<Task> action)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action(); // Execute all operations
                await _context.SaveChangesAsync();
                await transaction.CommitAsync(); //  Commit if everything is OK
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(); //  Rollback if something goes wrong
                throw;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
