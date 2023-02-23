using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    public partial class Invoice_Company_Connection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorCompanyPIB",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "CreatorCompanyId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CreatorCompanyId",
                table: "Invoices",
                column: "CreatorCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Companies_CreatorCompanyId",
                table: "Invoices",
                column: "CreatorCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Companies_CreatorCompanyId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CreatorCompanyId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CreatorCompanyId",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "CreatorCompanyPIB",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
