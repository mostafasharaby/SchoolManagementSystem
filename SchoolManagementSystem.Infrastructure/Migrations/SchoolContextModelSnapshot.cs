﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.Infrastructure.Data;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentID"));

                    b.Property<string>("AssignmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentID");

                    b.HasIndex("CourseID");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Attendance", b =>
                {
                    b.Property<int>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceID"));

                    b.Property<int>("ClassroomID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("AttendanceID");

                    b.HasIndex("ClassroomID");

                    b.HasIndex("StudentID");

                    b.ToTable("Attendances", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.BorrowedBook", b =>
                {
                    b.Property<int>("BorrowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowID"));

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibraryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("BorrowID");

                    b.HasIndex("LibraryID");

                    b.HasIndex("StudentID");

                    b.ToTable("BorrowedBooks", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Classroom", b =>
                {
                    b.Property<int>("ClassroomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassroomID"));

                    b.Property<string>("ClassroomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GradeID")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("ClassroomID");

                    b.HasIndex("GradeID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Classrooms", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Exam", b =>
                {
                    b.Property<int>("ExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExamTypeID")
                        .HasColumnType("int");

                    b.HasKey("ExamID");

                    b.HasIndex("CourseID");

                    b.HasIndex("ExamTypeID");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.ExamResult", b =>
                {
                    b.Property<int>("ExamResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamResultID"));

                    b.Property<int?>("ExamID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ExamResultID");

                    b.HasIndex("ExamID");

                    b.HasIndex("StudentID");

                    b.ToTable("ExamResults", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.ExamScore", b =>
                {
                    b.Property<int>("ExamScoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamScoreID"));

                    b.Property<int?>("ExamID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ExamScoreID");

                    b.HasIndex("ExamID");

                    b.HasIndex("StudentID");

                    b.ToTable("ExamScores", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.ExamType", b =>
                {
                    b.Property<int>("ExamTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamTypeID"));

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamTypeID");

                    b.ToTable("ExamTypes", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Fee", b =>
                {
                    b.Property<int>("FeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeeID"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("FeeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Fees", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Grade", b =>
                {
                    b.Property<int>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeID"));

                    b.Property<string>("GradeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeID");

                    b.ToTable("Grades", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Library", b =>
                {
                    b.Property<int>("LibraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibraryID"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("LibraryID");

                    b.ToTable("Libraries", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Parent", b =>
                {
                    b.Property<int>("ParentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParentID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParentID");

                    b.ToTable("Parents", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int?>("ClassroomID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("StudentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StudentDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFirstNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFirstNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentLastNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentLastNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.HasIndex("ClassroomID");

                    b.HasIndex("ParentID");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"));

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("TeacherAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TeacherDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherTypeID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("TeacherTypeID");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.TeacherType", b =>
                {
                    b.Property<int>("TeacherTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherTypeID"));

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherTypeID");

                    b.ToTable("TeacherTypes", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.TeacherCourse", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("TeacherCourses", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Views.UserRolesClaimsView", b =>
                {
                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("UserRolesClaimsView", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Assignment", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseID");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Attendance", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Classroom", "Classroom")
                        .WithMany("Attendances")
                        .HasForeignKey("ClassroomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.BorrowedBook", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Library", "Library")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("LibraryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Library");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Classroom", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Grade", "Grade")
                        .WithMany("Classrooms")
                        .HasForeignKey("GradeID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.Teacher", "Teacher")
                        .WithMany("Classrooms")
                        .HasForeignKey("TeacherID");

                    b.Navigation("Grade");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Course", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Enrollment", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Exam", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.ExamType", "ExamType")
                        .WithMany("Exams")
                        .HasForeignKey("ExamTypeID");

                    b.Navigation("Course");

                    b.Navigation("ExamType");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.ExamResult", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Exam", "Exam")
                        .WithMany("ExamResults")
                        .HasForeignKey("ExamID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany("ExamResults")
                        .HasForeignKey("StudentID");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.ExamScore", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Fee", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany("Fees")
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.Parent", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentID");

                    b.Navigation("Classroom");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Teacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("SchoolManagementSystem.Data.Entities.TeacherType", "TeacherType")
                        .WithMany("Teachers")
                        .HasForeignKey("TeacherTypeID");

                    b.Navigation("Department");

                    b.Navigation("TeacherType");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.TeacherCourse", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Course", "Course")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Classroom", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Enrollments");

                    b.Navigation("Exams");

                    b.Navigation("TeacherCourses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Exam", b =>
                {
                    b.Navigation("ExamResults");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.ExamType", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Grade", b =>
                {
                    b.Navigation("Classrooms");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Library", b =>
                {
                    b.Navigation("BorrowedBooks");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Parent", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("BorrowedBooks");

                    b.Navigation("Enrollments");

                    b.Navigation("ExamResults");

                    b.Navigation("Fees");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Teacher", b =>
                {
                    b.Navigation("Classrooms");

                    b.Navigation("TeacherCourses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.TeacherType", b =>
                {
                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
