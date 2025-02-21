using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRoomRepository Classrooms { get; }
        IStudentRepository Students { get; }
        IParentRepository Parents { get; }
        ITeacherRepository Teachers { get; }
        IBorrowedBookRepository BorrowedBooks { get; }
        ILibraryRepository Library { get; }
        IAttendanceRepository Attendances { get; }
        IEnrollmentRepository Enrollments { get; }
        ICourseRepository Courses { get; }
        IDepartmentRepository Departments { get; }
        IAssignmentRepository Assignments { get; }
        IExamRepository Exams { get; }
        IFeeRepository Fee { get; }
        IExamScoreRepository ExamScores { get; }
        IExamTypeRepository ExamsTypes { get; }
        IExamResultRepository ExamResults { get; }
        IGradeRepository Grades { get; }
        // GenericRepository<Fee> Fee { get; }
        IUserRolesClaimsRepository UserRolesClaims { get; }
        Task<bool> ExecuteTransactionAsync(Func<Task> action);
        Task<int> CompleteAsync();
    }
}
