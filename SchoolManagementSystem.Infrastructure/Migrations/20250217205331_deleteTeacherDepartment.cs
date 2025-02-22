using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteTeacherDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherDepartment_TeacherDepartmentDepartmentID",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "TeacherDepartment");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherDepartmentDepartmentID",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherDepartmentDepartmentID",
                table: "Teachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherDepartmentDepartmentID",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeacherDepartment",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDepartment", x => x.DepartmentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherDepartmentDepartmentID",
                table: "Teachers",
                column: "TeacherDepartmentDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherDepartment_TeacherDepartmentDepartmentID",
                table: "Teachers",
                column: "TeacherDepartmentDepartmentID",
                principalTable: "TeacherDepartment",
                principalColumn: "DepartmentID");
        }
    }
}
