using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_ERP.Migrations
{
    public partial class editFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeader_Id",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Items_Item_Id",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceHeader_Id",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_Item_Id",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceHeader_Id",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Item_Id",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetails_Id",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetails_Id",
                table: "InvoiceHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_InvoiceDetails_Id",
                table: "Items",
                column: "InvoiceDetails_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_InvoiceDetails_Id",
                table: "InvoiceHeaders",
                column: "InvoiceDetails_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeaders_InvoiceDetails_InvoiceDetails_Id",
                table: "InvoiceHeaders",
                column: "InvoiceDetails_Id",
                principalTable: "InvoiceDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_InvoiceDetails_InvoiceDetails_Id",
                table: "Items",
                column: "InvoiceDetails_Id",
                principalTable: "InvoiceDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeaders_InvoiceDetails_InvoiceDetails_Id",
                table: "InvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_InvoiceDetails_InvoiceDetails_Id",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_InvoiceDetails_Id",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHeaders_InvoiceDetails_Id",
                table: "InvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "InvoiceDetails_Id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "InvoiceDetails_Id",
                table: "InvoiceHeaders");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceHeader_Id",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Item_Id",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeader_Id",
                table: "InvoiceDetails",
                column: "InvoiceHeader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_Item_Id",
                table: "InvoiceDetails",
                column: "Item_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeader_Id",
                table: "InvoiceDetails",
                column: "InvoiceHeader_Id",
                principalTable: "InvoiceHeaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Items_Item_Id",
                table: "InvoiceDetails",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
