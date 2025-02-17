using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public SchoolContext _context;
        public IClassRoomRepository Classrooms { get; }
        public IParentRepository Parents { get; }
        public ITeacherRepository Teachers { get; }
        public IStudentRepository Students { get; }
        public ILibraryRepository Library { get; }
        public IFeeRepository Fee { get; }
        public IBorrowedBookRepository BorrowedBooks { get; }
        public IUserRolesClaimsRepository UserRolesClaims { get; }


        public UnitOfWork(SchoolContext context, IClassRoomRepository ClassRoomRepository, IParentRepository parentRepository, ITeacherRepository teacherRepository,
                           IStudentRepository studentRepository, IBorrowedBookRepository borrowedBookRepository, ILibraryRepository libraryRepository,
                           IUserRolesClaimsRepository userRolesClaims, IFeeRepository feeRepository)

        {
            _context = context;
            Classrooms = ClassRoomRepository;
            Parents = parentRepository;
            Teachers = teacherRepository;
            Students = studentRepository;
            UserRolesClaims = userRolesClaims;
            Library = libraryRepository;
            BorrowedBooks = borrowedBookRepository;
            Fee = feeRepository;
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
