using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Migrations
{
    public partial class shopingcartupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Shopping_card",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_card_ProductID",
                table: "Shopping_card",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shopping_card_Product_ProductID",
                table: "Shopping_card",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shopping_card_Product_ProductID",
                table: "Shopping_card");

            migrationBuilder.DropIndex(
                name: "IX_Shopping_card_ProductID",
                table: "Shopping_card");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Shopping_card");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
