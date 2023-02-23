using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    public partial class FixedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntenderForCompanyPIB",
                table: "Invoices",
                newName: "IntendedForCompanyPIB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntendedForCompanyPIB",
                table: "Invoices",
                newName: "IntenderForCompanyPIB");
        }
    }
}
