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

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _dbContext.Students.Include(st => st.Parent)
                                          .Include(st => st.Classroom)
                                            .ThenInclude(t => t.Teacher)
                                          .ToListAsync();
        }


        public async Task<Student?> GetStudentByIdResponseAsync(string studentId)
        {
            return await _dbContext.Students
                         .Include(st => st.Parent)
                         .Include(st => st.Classroom)
                         .FirstOrDefaultAsync(st => st.Id == studentId);

        }

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

        public async Task<List<Course>> GetStudentCoursesAsync(string studentId)
        {
            var courses = await _dbContext.Enrollments
                .Where(sc => sc.StudentID == studentId)
                .Select(sc => sc.Course)
                .ToListAsync();

            return courses;
        }

        public async Task<List<Attendance>> GetStudentAttendanceAsync(string studentId)
        {
            var attendanceRecords = await _dbContext.Attendances
                .Where(a => a.StudentID == studentId)
                .ToListAsync();

            return attendanceRecords;
        }

        public async Task<List<ExamResult>> GetStudentExamResultsAsync(string studentId)
        {
            var examResults = await _dbContext.ExamResults
                .Where(er => er.StudentID == studentId)
                .ToListAsync();

            return examResults;
        }

        public async Task<List<BorrowedBook>> GetStudentBorrowedBooksAsync(string studentId)
        {
            var borrowedBooks = await _dbContext.BorrowedBooks
                .Where(bb => bb.StudentID == studentId)
                .ToListAsync();

            return borrowedBooks;
        }

        public async Task<List<Fee>> GetStudentFeeHistoryAsync(string studentId)
        {
            var feePayments = await _dbContext.Fees
                .Where(fp => fp.StudentID == studentId)
                .ToListAsync();

            return feePayments;
        }
    }
}
