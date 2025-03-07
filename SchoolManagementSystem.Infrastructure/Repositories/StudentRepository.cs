using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {

        public StudentRepository(SchoolContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetAllStudentsAsync() =>
            await _dbContext.Students.Include(st => st.Parent)
                                      .Include(st => st.Classroom)
                                        .ThenInclude(t => t.Teacher)
                                      .ToListAsync();

        public async Task<Student?> GetStudentByIdResponseAsync(string studentId) =>
            await _dbContext.Students
                .Include(st => st.Parent)
                .Include(st => st.Classroom)
                .FirstOrDefaultAsync(st => st.Id == studentId);

        public async Task EnrollStudentInCourseAsync(string studentId, int courseId)
        {
            var courseEnrollment = new Enrollment
            {
                StudentID = studentId,
                CourseID = courseId,
                EnrollmentDate = DateTime.UtcNow
            };

            _dbContext.Enrollments.Add(courseEnrollment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetStudentCoursesAsync(string studentId) =>
            await _dbContext.Enrollments
                .Where(sc => sc.StudentID == studentId)
                .Select(sc => sc.Course)
                .ToListAsync();

        public async Task<List<Attendance>> GetStudentAttendanceAsync(string studentId) =>
            await _dbContext.Attendances
                .Where(a => a.StudentID == studentId)
                .ToListAsync();

        public async Task<List<ExamResult>> GetStudentExamResultsAsync(string studentId) =>
            await _dbContext.ExamResults
                .Where(er => er.StudentID == studentId)
                .ToListAsync();

        public async Task<List<BorrowedBook>> GetStudentBorrowedBooksAsync(string studentId) =>
            await _dbContext.BorrowedBooks
                .Where(bb => bb.StudentID == studentId)
                .ToListAsync();


        public async Task<List<Fee>> GetStudentFeeHistoryAsync(string studentId) =>
            await _dbContext.Fees
                .Where(fp => fp.StudentID == studentId)
                .ToListAsync();

    }
}
