using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        // Constructor to configure the DbContext
        //  public SchoolContext() { }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        // DbSet properties for each table
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentClassroom> StudentClassrooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<TeacherDepartment> TeacherDepartments { get; set; }
        public DbSet<TeacherType> TeacherTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Fee> Fees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowedBook>()
                .HasKey(b => b.BorrowID); // Explicitly setting BorrowID as Primary Key

            modelBuilder.Entity<TeacherDepartment>()
               .HasKey(b => b.DepartmentID);
        }

    }

}
