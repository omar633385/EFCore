using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo04.Migrations
{
    /// <inheritdoc />
    public partial class InhertanceMappingTPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTimeEmployees",
                table: "PartTimeEmployees");

            migrationBuilder.RenameTable(
                name: "PartTimeEmployees",
                newName: "EmployeeContainers");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourRate",
                table: "EmployeeContainers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHour",
                table: "EmployeeContainers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EmployeeContainers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "EmployeeContainers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeContainers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeContainers",
                table: "EmployeeContainers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeContainers",
                table: "EmployeeContainers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EmployeeContainers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "EmployeeContainers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EmployeeContainers");

            migrationBuilder.RenameTable(
                name: "EmployeeContainers",
                newName: "PartTimeEmployees");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourRate",
                table: "PartTimeEmployees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHour",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTimeEmployees",
                table: "PartTimeEmployees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullTimeEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeEmployees", x => x.Id);
                });
        }
    }
}
