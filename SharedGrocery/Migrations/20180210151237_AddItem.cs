using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SharedGrocery.Migrations
{
    public partial class AddItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryListGrocery");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groceries");

            migrationBuilder.AddColumn<int>(
                name: "GroceryListId",
                table: "Groceries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Groceries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Groceries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Barcode = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_GroceryListId",
                table: "Groceries",
                column: "GroceryListId");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_ItemId",
                table: "Groceries",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_GroceryLists_GroceryListId",
                table: "Groceries",
                column: "GroceryListId",
                principalTable: "GroceryLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_Items_ItemId",
                table: "Groceries",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_GroceryLists_GroceryListId",
                table: "Groceries");

            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_Items_ItemId",
                table: "Groceries");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Groceries_GroceryListId",
                table: "Groceries");

            migrationBuilder.DropIndex(
                name: "IX_Groceries_ItemId",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "GroceryListId",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Groceries");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groceries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroceryListGrocery",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false),
                    GroceryListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryListGrocery", x => new { x.GroceryId, x.GroceryListId });
                    table.ForeignKey(
                        name: "FK_GroceryListGrocery_Groceries_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "Groceries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryListGrocery_GroceryLists_GroceryListId",
                        column: x => x.GroceryListId,
                        principalTable: "GroceryLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListGrocery_GroceryListId",
                table: "GroceryListGrocery",
                column: "GroceryListId");
        }
    }
}
