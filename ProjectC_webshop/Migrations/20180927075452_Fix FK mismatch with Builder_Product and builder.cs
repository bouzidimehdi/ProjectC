using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectC_webshop.Migrations
{
    public partial class FixFKmismatchwithBuilder_Productandbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builder_Product_Builder_Product_ID",
                table: "Builder_Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Builder_Product_Builder_Builder_ID",
                table: "Builder_Product",
                column: "Builder_ID",
                principalTable: "Builder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builder_Product_Builder_Builder_ID",
                table: "Builder_Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Builder_Product_Builder_Product_ID",
                table: "Builder_Product",
                column: "Product_ID",
                principalTable: "Builder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
