using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_ERP.Migrations
{
    public partial class supplierStatement2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierAccountStatements_Customers_Customer_Id",
                table: "SupplierAccountStatements");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "SupplierAccountStatements",
                newName: "Supplier_Id");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierAccountStatements_Customer_Id",
                table: "SupplierAccountStatements",
                newName: "IX_SupplierAccountStatements_Supplier_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierAccountStatements_Suppliers_Supplier_Id",
                table: "SupplierAccountStatements",
                column: "Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierAccountStatements_Customers_CustomerId",
                table: "SupplierAccountStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierAccountStatements_Suppliers_Supplier_Id",
                table: "SupplierAccountStatements");

            migrationBuilder.DropIndex(
                name: "IX_SupplierAccountStatements_CustomerId",
                table: "SupplierAccountStatements");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SupplierAccountStatements");

            migrationBuilder.RenameColumn(
                name: "Supplier_Id",
                table: "SupplierAccountStatements",
                newName: "Customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierAccountStatements_Supplier_Id",
                table: "SupplierAccountStatements",
                newName: "IX_SupplierAccountStatements_Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierAccountStatements_Customers_Customer_Id",
                table: "SupplierAccountStatements",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
