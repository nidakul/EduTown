using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class postComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaggedUserId",
                table: "PostComments");

            migrationBuilder.CreateTable(
                name: "PostCommentTaggedUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCommentId = table.Column<int>(type: "int", nullable: false),
                    TaggedUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCommentTaggedUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCommentTaggedUser_PostComments_PostCommentId",
                        column: x => x.PostCommentId,
                        principalTable: "PostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTaggedUser_PostCommentId",
                table: "PostCommentTaggedUser",
                column: "PostCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCommentTaggedUser");

            migrationBuilder.AddColumn<string>(
                name: "TaggedUserId",
                table: "PostComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
