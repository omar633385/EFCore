using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo04.Migrations
{
    /// <inheritdoc />
    public partial class MappingView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view EmployeeDepartmentView
                with encryption
                as
                select e.Id as empId,e.Name,d.DeptId,d.DeptName
                from [dbo].[Departments] d
                join [dbo].[Employees] e
                on d.DeptId=e.DepartmentId
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop View EmployeeDepartmentView");
        }
    }
}
