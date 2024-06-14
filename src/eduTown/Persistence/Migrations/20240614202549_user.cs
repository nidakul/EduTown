using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorDepartment_Department_DepartmentId",
                table: "InstructorDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorDepartment_Instructors_InstructorId1",
                table: "InstructorDepartment");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorDepartment",
                table: "InstructorDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "InstructorDepartment",
                newName: "InstructorDepartments");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorDepartment_InstructorId1",
                table: "InstructorDepartments",
                newName: "IX_InstructorDepartments_InstructorId1");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorDepartment_DepartmentId",
                table: "InstructorDepartments",
                newName: "IX_InstructorDepartments_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorDepartments",
                table: "InstructorDepartments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorDepartments_Departments_DepartmentId",
                table: "InstructorDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorDepartments_Instructors_InstructorId1",
                table: "InstructorDepartments",
                column: "InstructorId1",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorDepartments_Departments_DepartmentId",
                table: "InstructorDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorDepartments_Instructors_InstructorId1",
                table: "InstructorDepartments");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorDepartments",
                table: "InstructorDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "InstructorDepartments",
                newName: "InstructorDepartment");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorDepartments_InstructorId1",
                table: "InstructorDepartment",
                newName: "IX_InstructorDepartment_InstructorId1");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorDepartments_DepartmentId",
                table: "InstructorDepartment",
                newName: "IX_InstructorDepartment_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorDepartment",
                table: "InstructorDepartment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorDepartment_Department_DepartmentId",
                table: "InstructorDepartment",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorDepartment_Instructors_InstructorId1",
                table: "InstructorDepartment",
                column: "InstructorId1",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
