using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Views;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class SchoolContext : IdentityDbContext<AppUser>
    {
        // Constructor to configure the DbContext
        //public SchoolContext() { }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        // DbSet properties for each table
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        // public DbSet<StudentClassroom> StudentClassrooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        // public DbSet<TeacherDepartment> TeacherDepartments { get; set; }  
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<TeacherType> TeacherTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ExamScore> ExamScores { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Fee> Fees { get; set; }



        //views 
        public DbSet<UserRolesClaimsView> UserRolesClaimsView { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowedBook>()
               .HasKey(b => b.BorrowID); // Explicitly setting BorrowID as Primary Key

            //modelBuilder.Entity<TeacherDepartment>()
            //   .HasKey(b => b.DepartmentID);

            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<UserRolesClaimsView>()
               .ToView("UserRolesClaimsView") // Explicitly map to the view
               .HasNoKey();


            modelBuilder.Entity<TeacherCourse>()
               .HasKey(tc => new { tc.TeacherID, tc.CourseID });
            // modelBuilder.ApplyConfiguration(new StudentConfig());  the 4-way 
        }
        /// <summary>
        /// Only 4 Ways to Mapp Object Model to Storage Model
        /// 1. Follow EF Core Convensions
        /// 2. Data Annotation (in Entity Class)
        /// 3. Fluent API ( OnModelCreating Funciton in Context class)
        /// 4. Configuration Class (separate Configuration class per Entity)
        /// </summary>


    }

}
