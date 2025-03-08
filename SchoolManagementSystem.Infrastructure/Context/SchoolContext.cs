using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Entities.RefreshToken;
using SchoolManagementSystem.Data.Views;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class SchoolContext : IdentityDbContext<AppUser>
    {
        //public SchoolContext() { }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BorrowedBook>()
               .HasKey(b => b.BorrowID);

            modelBuilder
               .Entity<UserRolesClaimsView>()
               .ToView("UserRolesClaimsView") // Explicitly map to the view
               .HasNoKey();

            modelBuilder.Entity<TeacherCourse>()
               .HasOne(tc => tc.Teacher)
               .WithMany(t => t.TeacherCourses)
               .HasForeignKey(tc => tc.TeacherID)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeacherCourses)
                .HasForeignKey(tc => tc.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Classroom)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassroomID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()  // i used that as i make sort on student alot so i need an index 
                .HasIndex(i => new { i.StudentFirstNameAr, i.StudentFirstNameEn, i.StudentLastNameAr, i.StudentLastNameEn })
                .IsUnique();

            modelBuilder.Entity<Student>().ToTable("Students"); // for TPT 
            modelBuilder.Entity<Teacher>().ToTable("Teachers"); // for TPT 

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
