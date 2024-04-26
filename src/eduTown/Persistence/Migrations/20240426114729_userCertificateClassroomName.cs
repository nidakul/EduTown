using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userCertificateClassroomName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCertificates_Classrooms_ClassroomId",
                table: "UserCertificates");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "UserCertificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomName",
                table: "UserCertificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCertificates_Classrooms_ClassroomId",
                table: "UserCertificates",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCertificates_Classrooms_ClassroomId",
                table: "UserCertificates");

            migrationBuilder.DropColumn(
                name: "ClassroomName",
                table: "UserCertificates");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "UserCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCertificates_Classrooms_ClassroomId",
                table: "UserCertificates",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
