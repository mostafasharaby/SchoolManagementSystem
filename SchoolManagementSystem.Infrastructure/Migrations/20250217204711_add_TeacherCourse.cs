using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_TeacherCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_TeacherDepartments_TeacherDepartmentDepartmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherDepartments_TeacherDepartmentDepartmentID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherDepartmentDepartmentID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherID",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherDepartments",
                table: "TeacherDepartments");

            migrationBuilder.DropColumn(
                name: "TeacherDepartmentDepartmentID",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "TeacherDepartments",
                newName: "TeacherDepartment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDepartment",
                table: "TeacherDepartment",
                column: "DepartmentID");

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.TeacherID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseID",
                table: "TeacherCourses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherDepartment_TeacherDepartmentDepartmentID",
                table: "Teachers",
                column: "TeacherDepartmentDepartmentID",
                principalTable: "TeacherDepartment",
                principalColumn: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherDepartment_TeacherDepartmentDepartmentID",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherDepartment",
                table: "TeacherDepartment");

            migrationBuilder.RenameTable(
                name: "TeacherDepartment",
                newName: "TeacherDepartments");

            migrationBuilder.AddColumn<int>(
                name: "TeacherDepartmentDepartmentID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDepartments",
                table: "TeacherDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherDepartmentDepartmentID",
                table: "Courses",
                column: "TeacherDepartmentDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherID",
                table: "Courses",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_TeacherDepartments_TeacherDepartmentDepartmentID",
                table: "Courses",
                column: "TeacherDepartmentDepartmentID",
                principalTable: "TeacherDepartments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherID",
                table: "Courses",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherDepartments_TeacherDepartmentDepartmentID",
                table: "Teachers",
                column: "TeacherDepartmentDepartmentID",
                principalTable: "TeacherDepartments",
                principalColumn: "DepartmentID");
        }
    }
}
