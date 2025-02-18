using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteStudentClassRoom_Class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Classrooms_ClassroomID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Libraries_LibraryID",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Students_StudentID",
                table: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "StudentClassrooms");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "BorrowedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LibraryID",
                table: "BorrowedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomID",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Classrooms_ClassroomID",
                table: "Attendances",
                column: "ClassroomID",
                principalTable: "Classrooms",
                principalColumn: "ClassroomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentID",
                table: "Attendances",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Libraries_LibraryID",
                table: "BorrowedBooks",
                column: "LibraryID",
                principalTable: "Libraries",
                principalColumn: "LibraryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Students_StudentID",
                table: "BorrowedBooks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Classrooms_ClassroomID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Libraries_LibraryID",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Students_StudentID",
                table: "BorrowedBooks");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "BorrowedBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryID",
                table: "BorrowedBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomID",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "StudentClassrooms",
                columns: table => new
                {
                    StudentClassroomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassrooms", x => x.StudentClassroomID);
                    table.ForeignKey(
                        name: "FK_StudentClassrooms_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomID");
                    table.ForeignKey(
                        name: "FK_StudentClassrooms_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_ClassroomID",
                table: "StudentClassrooms",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_StudentID",
                table: "StudentClassrooms",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Classrooms_ClassroomID",
                table: "Attendances",
                column: "ClassroomID",
                principalTable: "Classrooms",
                principalColumn: "ClassroomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentID",
                table: "Attendances",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Libraries_LibraryID",
                table: "BorrowedBooks",
                column: "LibraryID",
                principalTable: "Libraries",
                principalColumn: "LibraryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Students_StudentID",
                table: "BorrowedBooks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }
    }
}
