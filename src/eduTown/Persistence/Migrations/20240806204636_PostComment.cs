using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PostComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PostComments_PostCommentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PostCommentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostCommentId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "TaggedUserId",
                table: "PostComments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaggedUserId",
                table: "PostComments");

            migrationBuilder.AddColumn<int>(
                name: "PostCommentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostCommentId",
                table: "Users",
                column: "PostCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PostComments_PostCommentId",
                table: "Users",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");
        }
    }
}
