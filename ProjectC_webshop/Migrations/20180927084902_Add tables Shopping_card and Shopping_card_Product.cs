using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectC_webshop.Migrations
{
    public partial class AddtablesShopping_cardandShopping_card_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shopping_card",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    User_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_card", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shopping_card_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_card_Product",
                columns: table => new
                {
                    Shopping_card_ID = table.Column<int>(nullable: false),
                    Product_ID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_card_Product", x => new { x.Shopping_card_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_Shopping_card_Product_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shopping_card_Product_Shopping_card_Shopping_card_ID",
                        column: x => x.Shopping_card_ID,
                        principalTable: "Shopping_card",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_card_User_ID",
                table: "Shopping_card",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_card_Product_ProductID",
                table: "Shopping_card_Product",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shopping_card_Product");

            migrationBuilder.DropTable(
                name: "Shopping_card");
        }
    }
}
