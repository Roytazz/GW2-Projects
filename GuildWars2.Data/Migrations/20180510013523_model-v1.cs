using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildWars2.Data.Migrations
{
    public partial class modelv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Dye",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dye", x => new { x.UserID, x.ItemID });
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    SkinID = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Delta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => new { x.UserID, x.ItemID, x.SkinID, x.StatID });
                });

            migrationBuilder.CreateTable(
                name: "Skin",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    SkinID = table.Column<int>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skin", x => new { x.UserID, x.SkinID });
                });

            migrationBuilder.CreateTable(
                name: "WalletEntry",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Delta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletEntry", x => new { x.UserID, x.CurrencyID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dye",
                schema: "GuildWars2.Data");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "GuildWars2.Data");

            migrationBuilder.DropTable(
                name: "Skin",
                schema: "GuildWars2.Data");

            migrationBuilder.DropTable(
                name: "WalletEntry",
                schema: "GuildWars2.Data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User",
                column: "Key");
        }
    }
}
