using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_ERP.Migrations
{
    public partial class supplierStatement3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierAccountStatements_Customers_CustomerId",
                table: "SupplierAccountStatements");

            migrationBuilder.DropIndex(
                name: "IX_SupplierAccountStatements_CustomerId",
                table: "SupplierAccountStatements");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SupplierAccountStatements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "SupplierAccountStatements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAccountStatements_CustomerId",
                table: "SupplierAccountStatements",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierAccountStatements_Customers_CustomerId",
                table: "SupplierAccountStatements",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
