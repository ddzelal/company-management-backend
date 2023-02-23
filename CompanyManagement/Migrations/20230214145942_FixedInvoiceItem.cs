using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    public partial class FixedInvoiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoicId",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "InvoicId",
                table: "InvoiceItems",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoicId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceItems",
                newName: "InvoicId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoicId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoicId",
                table: "InvoiceItems",
                column: "InvoicId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
