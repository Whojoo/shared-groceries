using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SharedGrocery.Migrations
{
    public partial class GroceryListAndGroceriesManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_GroceryLists_GroceryListId",
                table: "Groceries");

            migrationBuilder.DropIndex(
                name: "IX_Groceries_GroceryListId",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "GroceryListId",
                table: "Groceries");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryListGrocery");

            migrationBuilder.AddColumn<int>(
                name: "GroceryListId",
                table: "Groceries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_GroceryListId",
                table: "Groceries",
                column: "GroceryListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_GroceryLists_GroceryListId",
                table: "Groceries",
                column: "GroceryListId",
                principalTable: "GroceryLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
