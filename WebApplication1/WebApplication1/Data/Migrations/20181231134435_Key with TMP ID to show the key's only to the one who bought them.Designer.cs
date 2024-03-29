﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Data;

namespace WebApplication1.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181231134435_Key with TMP ID to show the key's only to the one who bought them")]
    partial class KeywithTMPIDtoshowthekeysonlytotheonewhoboughtthem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApplication1.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Street");

                    b.Property<int>("TPunten");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApplication1.Data.Key", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("License");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderID");

                    b.Property<float>("Price");

                    b.Property<int>("ProductID");

                    b.Property<bool>("Sold");

                    b.Property<int>("TMPID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("Key");
                });

            modelBuilder.Entity("WebApplication1.Data.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("OrderDate");

                    b.Property<float>("Paid");

                    b.Property<int>("PointsGain");

                    b.Property<int>("PointsSpend");

                    b.Property<string>("User_ID");

                    b.HasKey("ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApplication1.Data.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutText");

                    b.Property<int>("AchievementCount");

                    b.Property<int>("AchievementHighlightedCount");

                    b.Property<string>("Background");

                    b.Property<bool>("CategoryCoop");

                    b.Property<bool>("CategoryInAppPurchase");

                    b.Property<bool>("CategoryIncludeLevelEditor");

                    b.Property<bool>("CategoryIncludeSrcSDK");

                    b.Property<bool>("CategoryMMO");

                    b.Property<bool>("CategoryMultiplayer");

                    b.Property<bool>("CategorySinglePlayer");

                    b.Property<bool>("CategoryVRSupport");

                    b.Property<bool>("ControllerSupport");

                    b.Property<int>("DLCCount");

                    b.Property<string>("DRMNotice");

                    b.Property<int>("DemoCount");

                    b.Property<string>("DetailedDescrip");

                    b.Property<int>("DeveloperCount");

                    b.Property<string>("ExtUserAcctNotice");

                    b.Property<bool>("FreeVerAvail");

                    b.Property<bool>("GenreIsAction");

                    b.Property<bool>("GenreIsAdventure");

                    b.Property<bool>("GenreIsCasual");

                    b.Property<bool>("GenreIsEarlyAccess");

                    b.Property<bool>("GenreIsFreeToPlay");

                    b.Property<bool>("GenreIsIndie");

                    b.Property<bool>("GenreIsMassivelyMultiplayer");

                    b.Property<bool>("GenreIsNonGame");

                    b.Property<bool>("GenreIsRPG");

                    b.Property<bool>("GenreIsRacing");

                    b.Property<bool>("GenreIsSimulation");

                    b.Property<bool>("GenreIsSports");

                    b.Property<bool>("GenreIsStrategy");

                    b.Property<string>("HeaderImage");

                    b.Property<bool>("IsFree");

                    b.Property<string>("LegalNotice");

                    b.Property<string>("LinuxMinReqsText");

                    b.Property<string>("LinuxRecReqsText");

                    b.Property<bool>("LinuxReqsHaveMin");

                    b.Property<bool>("LinuxReqsHaveRec");

                    b.Property<string>("MacMinReqsText");

                    b.Property<string>("MacRecReqsText");

                    b.Property<bool>("MacReqsHaveMin");

                    b.Property<bool>("MacReqsHaveRec");

                    b.Property<int>("Metacritic");

                    b.Property<int>("MovieCount");

                    b.Property<string>("PCMinReqsText");

                    b.Property<string>("PCRecReqsText");

                    b.Property<bool>("PCReqsHaveMin");

                    b.Property<bool>("PCReqsHaveRec");

                    b.Property<int>("PackageCount");

                    b.Property<bool>("PlatformLinux");

                    b.Property<bool>("PlatformMac");

                    b.Property<bool>("PlatformWindows");

                    b.Property<string>("PriceCurrency");

                    b.Property<float>("PriceFinal");

                    b.Property<float>("PriceInitial");

                    b.Property<int>("PublisherCount");

                    b.Property<bool>("PurchaseAvail");

                    b.Property<int>("QueryID");

                    b.Property<string>("QueryName");

                    b.Property<int>("RecommendationCount");

                    b.Property<string>("ReleaseDate");

                    b.Property<int>("RequiredAge");

                    b.Property<int>("ResponseID");

                    b.Property<string>("ResponseName");

                    b.Property<string>("Reviews");

                    b.Property<int>("ScreenshotCount");

                    b.Property<string>("ShortDescrip");

                    b.Property<int>("SteamSpyOwners");

                    b.Property<int>("SteamSpyOwnersVariance");

                    b.Property<int>("SteamSpyPlayersEstimate");

                    b.Property<int>("SteamSpyPlayersVariance");

                    b.Property<bool>("SubscriptionAvail");

                    b.Property<string>("SupportEmail");

                    b.Property<string>("SupportURL");

                    b.Property<string>("SupportedLanguages");

                    b.Property<string>("Website");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebApplication1.Data.Shopping_card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductID");

                    b.Property<string>("User_ID");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("User_ID")
                        .IsUnique()
                        .HasFilter("[User_ID] IS NOT NULL");

                    b.ToTable("Shopping_card");
                });

            modelBuilder.Entity("WebApplication1.Data.Shopping_card_Product", b =>
                {
                    b.Property<int>("Shopping_card_ID");

                    b.Property<int>("Product_ID");

                    b.Property<int?>("ProductID");

                    b.Property<int>("quantity");

                    b.HasKey("Shopping_card_ID", "Product_ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Shopping_Card_Products");
                });

            modelBuilder.Entity("WebApplication1.Data.User_Wishlist", b =>
                {
                    b.Property<string>("User_ID");

                    b.Property<int>("Product_ID");

                    b.HasKey("User_ID", "Product_ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("User_wishlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication1.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication1.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication1.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Data.Key", b =>
                {
                    b.HasOne("WebApplication1.Data.Order", "Order")
                        .WithMany("Keys")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Data.Product", "Products")
                        .WithMany("Keys")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Data.Order", b =>
                {
                    b.HasOne("WebApplication1.Data.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("WebApplication1.Data.Shopping_card", b =>
                {
                    b.HasOne("WebApplication1.Data.Product")
                        .WithMany("ShoppingCart")
                        .HasForeignKey("ProductID");

                    b.HasOne("WebApplication1.Data.ApplicationUser", "User")
                        .WithOne("ShoppingCard")
                        .HasForeignKey("WebApplication1.Data.Shopping_card", "User_ID");
                });

            modelBuilder.Entity("WebApplication1.Data.Shopping_card_Product", b =>
                {
                    b.HasOne("WebApplication1.Data.Product", "Product")
                        .WithMany("ShoppingCardProducts")
                        .HasForeignKey("ProductID");

                    b.HasOne("WebApplication1.Data.Shopping_card", "ShoppingCard")
                        .WithMany("ShoppingCardProducts")
                        .HasForeignKey("Shopping_card_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Data.User_Wishlist", b =>
                {
                    b.HasOne("WebApplication1.Data.Product", "Product")
                        .WithMany("Wishlists")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Data.ApplicationUser", "User")
                        .WithMany("Wishlists")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
