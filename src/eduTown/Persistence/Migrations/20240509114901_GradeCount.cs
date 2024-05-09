using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GradeCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamCount",
                table: "StudentGrades");

            migrationBuilder.AddColumn<int>(
                name: "GradeCount",
                table: "GradeTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeCount",
                table: "GradeTypes");

            migrationBuilder.AddColumn<int>(
                name: "ExamCount",
                table: "StudentGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
