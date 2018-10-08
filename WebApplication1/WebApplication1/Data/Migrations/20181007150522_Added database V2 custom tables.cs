using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Migrations
{
    public partial class AddeddatabaseV2customtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Housenumber",
                table: "AspNetUsers",
                newName: "HouseNumber");

            migrationBuilder.CreateTable(
                name: "Builder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Factuur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Building_nummer = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    E_mail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Payed = table.Column<bool>(nullable: false),
                    Streetname = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Zip_Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factuur", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AboutText = table.Column<string>(nullable: true),
                    AchievementCount = table.Column<int>(nullable: false),
                    AchievementHighlightedCount = table.Column<int>(nullable: false),
                    Background = table.Column<string>(nullable: true),
                    CategoryCoop = table.Column<bool>(nullable: false),
                    CategoryInAppPurchase = table.Column<bool>(nullable: false),
                    CategoryIncludeLevelEditor = table.Column<bool>(nullable: false),
                    CategoryIncludeSrcSDK = table.Column<bool>(nullable: false),
                    CategoryMMO = table.Column<bool>(nullable: false),
                    CategoryMultiplayer = table.Column<bool>(nullable: false),
                    CategorySinglePlayer = table.Column<bool>(nullable: false),
                    CategoryVRSupport = table.Column<bool>(nullable: false),
                    ControllerSupport = table.Column<bool>(nullable: false),
                    DLCCount = table.Column<int>(nullable: false),
                    DRMNotice = table.Column<string>(nullable: true),
                    DemoCount = table.Column<int>(nullable: false),
                    DetailedDescrip = table.Column<string>(nullable: true),
                    DeveloperCount = table.Column<int>(nullable: false),
                    ExtUserAcctNotice = table.Column<string>(nullable: true),
                    FreeVerAvail = table.Column<bool>(nullable: false),
                    GenreIsAction = table.Column<bool>(nullable: false),
                    GenreIsAdventure = table.Column<bool>(nullable: false),
                    GenreIsCasual = table.Column<bool>(nullable: false),
                    GenreIsEarlyAccess = table.Column<bool>(nullable: false),
                    GenreIsFreeToPlay = table.Column<bool>(nullable: false),
                    GenreIsIndie = table.Column<bool>(nullable: false),
                    GenreIsMassivelyMultiplayer = table.Column<bool>(nullable: false),
                    GenreIsNonGame = table.Column<bool>(nullable: false),
                    GenreIsRPG = table.Column<bool>(nullable: false),
                    GenreIsRacing = table.Column<bool>(nullable: false),
                    GenreIsSimulation = table.Column<bool>(nullable: false),
                    GenreIsSports = table.Column<bool>(nullable: false),
                    GenreIsStrategy = table.Column<bool>(nullable: false),
                    HeaderImage = table.Column<string>(nullable: true),
                    IsFree = table.Column<bool>(nullable: false),
                    LegalNotice = table.Column<string>(nullable: true),
                    LinuxMinReqsText = table.Column<string>(nullable: true),
                    LinuxRecReqsText = table.Column<string>(nullable: true),
                    LinuxReqsHaveMin = table.Column<bool>(nullable: false),
                    LinuxReqsHaveRec = table.Column<bool>(nullable: false),
                    MacMinReqsText = table.Column<string>(nullable: true),
                    MacRecReqsText = table.Column<string>(nullable: true),
                    MacReqsHaveMin = table.Column<bool>(nullable: false),
                    MacReqsHaveRec = table.Column<bool>(nullable: false),
                    Metacritic = table.Column<int>(nullable: false),
                    MovieCount = table.Column<int>(nullable: false),
                    PCMinReqsText = table.Column<string>(nullable: true),
                    PCRecReqsText = table.Column<string>(nullable: true),
                    PCReqsHaveMin = table.Column<bool>(nullable: false),
                    PCReqsHaveRec = table.Column<bool>(nullable: false),
                    PackageCount = table.Column<int>(nullable: false),
                    PlatformLinux = table.Column<bool>(nullable: false),
                    PlatformMac = table.Column<bool>(nullable: false),
                    PlatformWindows = table.Column<bool>(nullable: false),
                    PriceCurrency = table.Column<string>(nullable: true),
                    PriceFinal = table.Column<float>(nullable: false),
                    PriceInitial = table.Column<float>(nullable: false),
                    PublisherCount = table.Column<int>(nullable: false),
                    PurchaseAvail = table.Column<bool>(nullable: false),
                    QueryID = table.Column<int>(nullable: false),
                    QueryName = table.Column<string>(nullable: true),
                    RecommendationCount = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<string>(nullable: true),
                    RequiredAge = table.Column<int>(nullable: false),
                    ResponseID = table.Column<int>(nullable: false),
                    ResponseName = table.Column<string>(nullable: true),
                    Reviews = table.Column<string>(nullable: true),
                    ScreenshotCount = table.Column<int>(nullable: false),
                    ShortDescrip = table.Column<string>(nullable: true),
                    SteamSpyOwners = table.Column<int>(nullable: false),
                    SteamSpyOwnersVariance = table.Column<int>(nullable: false),
                    SteamSpyPlayersEstimate = table.Column<int>(nullable: false),
                    SteamSpyPlayersVariance = table.Column<int>(nullable: false),
                    SubscriptionAvail = table.Column<bool>(nullable: false),
                    SupportEmail = table.Column<string>(nullable: true),
                    SupportURL = table.Column<string>(nullable: true),
                    SupportedLanguages = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    User_role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Role_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_card",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_card", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shopping_card_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Factuur_ID = table.Column<int>(nullable: false),
                    User_ID = table.Column<string>(nullable: true)
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
                        name: "FK_Order_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Builder_Product",
                columns: table => new
                {
                    Builder_ID = table.Column<int>(nullable: false),
                    Product_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builder_Product", x => new { x.Builder_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_Builder_Product_Builder_Builder_ID",
                        column: x => x.Builder_ID,
                        principalTable: "Builder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Builder_Product_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Key",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    License = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    Sold = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Key_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_wishlist",
                columns: table => new
                {
                    User_ID = table.Column<string>(nullable: false),
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
                        name: "FK_User_wishlist_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Card_Products",
                columns: table => new
                {
                    Shopping_card_ID = table.Column<int>(nullable: false),
                    Product_ID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Card_Products", x => new { x.Shopping_card_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_Shopping_Card_Products_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shopping_Card_Products_Shopping_card_Shopping_card_ID",
                        column: x => x.Shopping_card_ID,
                        principalTable: "Shopping_card",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factuur_Producten",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Factuur_ID = table.Column<int>(nullable: false),
                    Key_ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
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
                name: "Orderd_Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "IX_Builder_Product_Product_ID",
                table: "Builder_Product",
                column: "Product_ID");

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
                name: "IX_Key_ProductID",
                table: "Key",
                column: "ProductID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_card_User_ID",
                table: "Shopping_card",
                column: "User_ID",
                unique: true,
                filter: "[User_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Card_Products_ProductID",
                table: "Shopping_Card_Products",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_User_wishlist_Product_ID",
                table: "User_wishlist",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Builder_Product");

            migrationBuilder.DropTable(
                name: "Factuur_Producten");

            migrationBuilder.DropTable(
                name: "Orderd_Product");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Shopping_Card_Products");

            migrationBuilder.DropTable(
                name: "User_wishlist");

            migrationBuilder.DropTable(
                name: "Builder");

            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Shopping_card");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Factuur");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "AspNetUsers",
                newName: "Housenumber");
        }
    }
}
