using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEMS.Migrations
{
    public partial class designation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignationNames",
                table: "EmployeeDesignation",
                newName: "DesignationName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignationName",
                table: "EmployeeDesignation",
                newName: "DesignationNames");
        }
    }
}
