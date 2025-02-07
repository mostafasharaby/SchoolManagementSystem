using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentLastName",
                table: "Students",
                newName: "StudentLastNameEn");

            migrationBuilder.RenameColumn(
                name: "StudentFirstName",
                table: "Students",
                newName: "StudentLastNameAr");

            migrationBuilder.AddColumn<string>(
                name: "StudentFirstNameAr",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentFirstNameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomID",
                table: "Students",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentID",
                table: "Students",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_TeacherID",
                table: "Classrooms",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Teachers_TeacherID",
                table: "Classrooms",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classrooms_ClassroomID",
                table: "Students",
                column: "ClassroomID",
                principalTable: "Classrooms",
                principalColumn: "ClassroomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentID",
                table: "Students",
                column: "ParentID",
                principalTable: "Parents",
                principalColumn: "ParentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Teachers_TeacherID",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classrooms_ClassroomID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassroomID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_TeacherID",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "StudentFirstNameAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentFirstNameEn",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentLastNameEn",
                table: "Students",
                newName: "StudentLastName");

            migrationBuilder.RenameColumn(
                name: "StudentLastNameAr",
                table: "Students",
                newName: "StudentFirstName");
        }
    }
}
