using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_ERP.Migrations
{
    public partial class s3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_Item_Id",
                table: "InvoiceDetails");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_Item_Id",
                table: "InvoiceDetails",
                column: "Item_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_Item_Id",
                table: "InvoiceDetails");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_Item_Id",
                table: "InvoiceDetails",
                column: "Item_Id",
                unique: true,
                filter: "[Item_Id] IS NOT NULL");
        }
    }
}
