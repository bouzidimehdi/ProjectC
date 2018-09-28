using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectC_webshop.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shopping_card_Product_Product_ProductID",
                table: "Shopping_card_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shopping_card_Product_Shopping_card_Shopping_card_ID",
                table: "Shopping_card_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shopping_card_Product",
                table: "Shopping_card_Product");

            migrationBuilder.RenameTable(
                name: "Shopping_card_Product",
                newName: "Shopping_Card_Products");

            migrationBuilder.RenameIndex(
                name: "IX_Shopping_card_Product_ProductID",
                table: "Shopping_Card_Products",
                newName: "IX_Shopping_Card_Products_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shopping_Card_Products",
                table: "Shopping_Card_Products",
                columns: new[] { "Shopping_card_ID", "Product_ID" });

            migrationBuilder.CreateTable(
                name: "Factuur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Streetname = table.Column<string>(nullable: true),
                    Zip_Code = table.Column<string>(nullable: true),
                    Building_nummer = table.Column<int>(nullable: false),
                    E_mail = table.Column<string>(nullable: true),
                    Payed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factuur", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Factuur_Producten",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Key_ID = table.Column<int>(nullable: false),
                    Factuur_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factuur_Producten", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Factuur_Producten_Factuur_Factuur_ID",
                        column: x => x.Factuur_ID,
                        principalTable: "Factuur",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factuur_Producten_Key_Key_ID",
                        column: x => x.Key_ID,
                        principalTable: "Key",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    User_ID = table.Column<int>(nullable: false),
                    Factuur_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Factuur_Factuur_ID",
                        column: x => x.Factuur_ID,
                        principalTable: "Factuur",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderd_Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key_ID = table.Column<int>(nullable: false),
                    Order_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderd_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orderd_Product_Key_Key_ID",
                        column: x => x.Key_ID,
                        principalTable: "Key",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderd_Product_Order_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factuur_Producten_Factuur_ID",
                table: "Factuur_Producten",
                column: "Factuur_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Factuur_Producten_Key_ID",
                table: "Factuur_Producten",
                column: "Key_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Factuur_ID",
                table: "Order",
                column: "Factuur_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_ID",
                table: "Order",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderd_Product_Key_ID",
                table: "Orderd_Product",
                column: "Key_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderd_Product_Order_ID",
                table: "Orderd_Product",
                column: "Order_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shopping_Card_Products_Product_ProductID",
                table: "Shopping_Card_Products",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shopping_Card_Products_Shopping_card_Shopping_card_ID",
                table: "Shopping_Card_Products",
                column: "Shopping_card_ID",
                principalTable: "Shopping_card",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shopping_Card_Products_Product_ProductID",
                table: "Shopping_Card_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shopping_Card_Products_Shopping_card_Shopping_card_ID",
                table: "Shopping_Card_Products");

            migrationBuilder.DropTable(
                name: "Factuur_Producten");

            migrationBuilder.DropTable(
                name: "Orderd_Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Factuur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shopping_Card_Products",
                table: "Shopping_Card_Products");

            migrationBuilder.RenameTable(
                name: "Shopping_Card_Products",
                newName: "Shopping_card_Product");

            migrationBuilder.RenameIndex(
                name: "IX_Shopping_Card_Products_ProductID",
                table: "Shopping_card_Product",
                newName: "IX_Shopping_card_Product_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shopping_card_Product",
                table: "Shopping_card_Product",
                columns: new[] { "Shopping_card_ID", "Product_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Shopping_card_Product_Product_ProductID",
                table: "Shopping_card_Product",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shopping_card_Product_Shopping_card_Shopping_card_ID",
                table: "Shopping_card_Product",
                column: "Shopping_card_ID",
                principalTable: "Shopping_card",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
