using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Rest_OF_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Dept_Id",
                table: "Instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dept_Id",
                table: "Students",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dept_Id",
                table: "Instructors",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Ins_Id",
                table: "Departments",
                column: "Ins_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Top_Id",
                table: "Courses",
                column: "Top_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Topics_Top_Id",
                table: "Courses",
                column: "Top_Id",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_Ins_Id",
                table: "Departments",
                column: "Ins_Id",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_Dept_Id",
                table: "Instructors",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Dept_Id",
                table: "Students",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Topics_Top_Id",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_Ins_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_Dept_Id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Dept_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Dept_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Dept_Id",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Ins_Id",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Top_Id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_Id",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
