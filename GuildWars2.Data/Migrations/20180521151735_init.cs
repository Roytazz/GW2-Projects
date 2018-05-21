using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GuildWars2.UserData");

            migrationBuilder.CreateTable(
                name: "CategoryValue",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Delta = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryValue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dye",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    DyeID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dye", x => new { x.UserID, x.DyeID });
                    table.ForeignKey(
                        name: "FK_Dye_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "GuildWars2.UserData",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: false),
                    SkinID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Delta = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "GuildWars2.UserData",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Key",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    APIKey = table.Column<string>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => new { x.UserID, x.APIKey });
                    table.ForeignKey(
                        name: "FK_Key_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "GuildWars2.UserData",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mini",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    MiniID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mini", x => new { x.UserID, x.MiniID });
                    table.ForeignKey(
                        name: "FK_Mini_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "GuildWars2.UserData",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skin",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    SkinID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skin", x => new { x.UserID, x.SkinID });
                    table.ForeignKey(
                        name: "FK_Skin_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "GuildWars2.UserData",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Delta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wallet_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "GuildWars2.UserData",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserID",
                schema: "GuildWars2.UserData",
                table: "Item",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryValue",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "Dye",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "Key",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "Mini",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "Skin",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "Wallet",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropTable(
                name: "User",
                schema: "GuildWars2.UserData");
        }
    }
}
