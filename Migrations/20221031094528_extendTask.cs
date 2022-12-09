using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_ERP.Migrations
{
    public partial class extendTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesBillHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remainder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Supplier_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesBillHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesBillHeaders_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchasesBillDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Item_Cost = table.Column<int>(type: "int", nullable: false),
                    PurchasesBillHeader_Id = table.Column<int>(type: "int", nullable: true),
                    Item_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesBillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesBillDetails_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasesBillDetails_PurchasesBillHeaders_PurchasesBillHeader_Id",
                        column: x => x.PurchasesBillHeader_Id,
                        principalTable: "PurchasesBillHeaders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesBillDetails_Item_Id",
                table: "PurchasesBillDetails",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesBillDetails_PurchasesBillHeader_Id",
                table: "PurchasesBillDetails",
                column: "PurchasesBillHeader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesBillHeaders_Supplier_Id",
                table: "PurchasesBillHeaders",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Item_Id",
                table: "Stores",
                column: "Item_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasesBillDetails");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "PurchasesBillHeaders");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
