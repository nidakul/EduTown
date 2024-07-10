using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchoolTypeClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolTypeClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolTypeId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTypeClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolTypeClasses_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolTypeClasses_SchoolTypes_SchoolTypeId",
                        column: x => x.SchoolTypeId,
                        principalTable: "SchoolTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTypeClasses_ClassroomId",
                table: "SchoolTypeClasses",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTypeClasses_SchoolTypeId",
                table: "SchoolTypeClasses",
                column: "SchoolTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolTypeClasses");
        }
    }
}
