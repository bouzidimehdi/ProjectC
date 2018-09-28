using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectC_webshop.Migrations
{
    public partial class AddtableUserwishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Key_Product_ProductsID",
                table: "Key");

            migrationBuilder.DropIndex(
                name: "IX_Key_ProductsID",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "ProductsID",
                table: "Key");

            migrationBuilder.CreateTable(
                name: "User_wishlist",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false),
                    Product_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_wishlist", x => new { x.User_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_User_wishlist_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_wishlist_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Key_ProductID",
                table: "Key",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_User_wishlist_Product_ID",
                table: "User_wishlist",
                column: "Product_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Key_Product_ProductID",
                table: "Key",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Key_Product_ProductID",
                table: "Key");

            migrationBuilder.DropTable(
                name: "User_wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Key_ProductID",
                table: "Key");

            migrationBuilder.AddColumn<int>(
                name: "ProductsID",
                table: "Key",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Key_ProductsID",
                table: "Key",
                column: "ProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Key_Product_ProductsID",
                table: "Key",
                column: "ProductsID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
