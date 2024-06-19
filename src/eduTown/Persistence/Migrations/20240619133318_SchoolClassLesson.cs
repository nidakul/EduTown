using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchoolClassLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolClassroomId",
                table: "SchoolClassrooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchoolClassLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolClassroomId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClassLesson_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolClassLesson_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassLesson_SchoolClassrooms_SchoolClassroomId",
                        column: x => x.SchoolClassroomId,
                        principalTable: "SchoolClassrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassLesson_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassrooms_SchoolClassroomId",
                table: "SchoolClassrooms",
                column: "SchoolClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassLesson_ClassroomId",
                table: "SchoolClassLesson",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassLesson_LessonId",
                table: "SchoolClassLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassLesson_SchoolClassroomId",
                table: "SchoolClassLesson",
                column: "SchoolClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassLesson_SchoolId",
                table: "SchoolClassLesson",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassrooms_SchoolClassrooms_SchoolClassroomId",
                table: "SchoolClassrooms",
                column: "SchoolClassroomId",
                principalTable: "SchoolClassrooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassrooms_SchoolClassrooms_SchoolClassroomId",
                table: "SchoolClassrooms");

            migrationBuilder.DropTable(
                name: "SchoolClassLesson");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClassrooms_SchoolClassroomId",
                table: "SchoolClassrooms");

            migrationBuilder.DropColumn(
                name: "SchoolClassroomId",
                table: "SchoolClassrooms");
        }
    }
}
