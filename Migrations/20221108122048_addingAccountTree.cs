using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_ERP.Migrations
{
    public partial class addingAccountTree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTree_Id",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTree_Id",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountTree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acc_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acc_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTree", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AccountTree_Id",
                table: "Suppliers",
                column: "AccountTree_Id",
                unique: true,
                filter: "[AccountTree_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountTree_Id",
                table: "Customers",
                column: "AccountTree_Id",
                unique: true,
                filter: "[AccountTree_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AccountTree_AccountTree_Id",
                table: "Customers",
                column: "AccountTree_Id",
                principalTable: "AccountTree",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AccountTree_AccountTree_Id",
                table: "Suppliers",
                column: "AccountTree_Id",
                principalTable: "AccountTree",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AccountTree_AccountTree_Id",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AccountTree_AccountTree_Id",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "AccountTree");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AccountTree_Id",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountTree_Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountTree_Id",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "AccountTree_Id",
                table: "Customers");
        }
    }
}
