using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GuildWars2.REST.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ItemDifference",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CurrencyDifference",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Listings = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InfixBuff",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SkillID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfixBuff", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AggregatedListing",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuysID = table.Column<int>(nullable: true),
                    SellsID = table.Column<int>(nullable: true),
                    Whitelisted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregatedListing", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_AggregatedListing_Listing_BuysID",
                        column: x => x.BuysID,
                        principalTable: "Listing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AggregatedListing_Listing_SellsID",
                        column: x => x.SellsID,
                        principalTable: "Listing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Infix",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuffID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infix", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Infix_InfixBuff_BuffID",
                        column: x => x.BuffID,
                        principalTable: "InfixBuff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfixAttribute",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attribute = table.Column<int>(nullable: false),
                    InfixID = table.Column<int>(nullable: true),
                    Modifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfixAttribute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InfixAttribute_Infix_InfixID",
                        column: x => x.InfixID,
                        principalTable: "Infix",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyCount = table.Column<int>(nullable: false),
                    Charges = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    DamageType = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DurationMS = table.Column<int>(nullable: false),
                    InfixUpgradeID = table.Column<int>(nullable: true),
                    MaxPower = table.Column<int>(nullable: false),
                    MinPower = table.Column<int>(nullable: false),
                    MiniPetID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NoSellOrSort = table.Column<bool>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false),
                    SecondarySuffixItemID = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Suffix = table.Column<string>(nullable: true),
                    SuffixItemID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UnlockType = table.Column<int>(nullable: false),
                    WeightClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemDetails_Infix_InfixUpgradeID",
                        column: x => x.InfixUpgradeID,
                        principalTable: "Infix",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChatLink = table.Column<string>(nullable: true),
                    DefaultSkin = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DetailsID = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rarity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    VendorValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_ItemDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "ItemDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AggregatedListing_BuysID",
                table: "AggregatedListing",
                column: "BuysID");

            migrationBuilder.CreateIndex(
                name: "IX_AggregatedListing_SellsID",
                table: "AggregatedListing",
                column: "SellsID");

            migrationBuilder.CreateIndex(
                name: "IX_Infix_BuffID",
                table: "Infix",
                column: "BuffID");

            migrationBuilder.CreateIndex(
                name: "IX_InfixAttribute_InfixID",
                table: "InfixAttribute",
                column: "InfixID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_DetailsID",
                table: "Item",
                column: "DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_InfixUpgradeID",
                table: "ItemDetails",
                column: "InfixUpgradeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregatedListing");

            migrationBuilder.DropTable(
                name: "InfixAttribute");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "ItemDetails");

            migrationBuilder.DropTable(
                name: "Infix");

            migrationBuilder.DropTable(
                name: "InfixBuff");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ItemDifference");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CurrencyDifference");
        }
    }
}
