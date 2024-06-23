using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchoolLessonDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_SchoolLessons_SchoolLessonId",
                table: "Classrooms");

            migrationBuilder.DropTable(
                name: "SchoolLessons");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_SchoolLessonId",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "SchoolLessonId",
                table: "Classrooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolLessonId",
                table: "Classrooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchoolLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolLessons_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_SchoolLessonId",
                table: "Classrooms",
                column: "SchoolLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLessons_LessonId",
                table: "SchoolLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLessons_SchoolId",
                table: "SchoolLessons",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_SchoolLessons_SchoolLessonId",
                table: "Classrooms",
                column: "SchoolLessonId",
                principalTable: "SchoolLessons",
                principalColumn: "Id");
        }
    }
}
