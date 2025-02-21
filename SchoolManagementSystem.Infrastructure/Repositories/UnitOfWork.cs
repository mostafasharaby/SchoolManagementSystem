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
        public IAttendanceRepository Attendances { get; }
        public IFeeRepository Fee { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IBorrowedBookRepository BorrowedBooks { get; }
        public IDepartmentRepository Departments { get; }
        public IAssignmentRepository Assignments { get; }
        public IExamRepository Exams { get; }
        public IExamScoreRepository ExamScores { get; }
        public IExamTypeRepository ExamsTypes { get; }
        public IGradeRepository Grades { get; }
        public IUserRolesClaimsRepository UserRolesClaims { get; }
        public ICourseRepository Courses { get; }
        public IExamResultRepository ExamResults { get; }

        public UnitOfWork(SchoolContext context, IClassRoomRepository ClassRoomRepository, IParentRepository parentRepository, ITeacherRepository teacherRepository,
                           IStudentRepository studentRepository, IBorrowedBookRepository borrowedBookRepository, ILibraryRepository libraryRepository,
                           IUserRolesClaimsRepository userRolesClaims, IFeeRepository feeRepository, IAttendanceRepository attendances, IEnrollmentRepository enrollment,
                           ICourseRepository courses, IDepartmentRepository departments, IAssignmentRepository assignments, IExamRepository exams, IExamResultRepository examResults,
                           IExamScoreRepository examScores, IExamTypeRepository examsTypes, IGradeRepository grades)

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
            Attendances = attendances;
            Enrollments = enrollment;
            Courses = courses;
            Departments = departments;
            Assignments = assignments;
            Exams = exams;
            ExamResults = examResults;
            ExamScores = examScores;
            ExamsTypes = examsTypes;
            Grades = grades;
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
