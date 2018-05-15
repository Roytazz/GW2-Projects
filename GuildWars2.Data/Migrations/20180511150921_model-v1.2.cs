using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class modelv12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Skin");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Dye");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "CategoryValue");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "GuildWars2.Data",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                schema: "GuildWars2.Data",
                table: "Dye",
                newName: "DyeID");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "GuildWars2.Data",
                table: "Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mini",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    MiniID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mini", x => new { x.UserID, x.MiniID });
                });

            migrationBuilder.InsertData(
                schema: "GuildWars2.Data",
                table: "Category",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 },
                    { 8, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mini",
                schema: "GuildWars2.Data");

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "GuildWars2.Data",
                table: "Category",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "GuildWars2.Data",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "DyeID",
                schema: "GuildWars2.Data",
                table: "Dye",
                newName: "ItemID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Wallet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Skin",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Item",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Dye",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "CategoryValue",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "GuildWars2.Data",
                table: "Category",
                nullable: true);
        }
    }
}
