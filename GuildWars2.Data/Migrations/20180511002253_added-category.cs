using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildWars2.Data.Migrations
{
    public partial class addedcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Wallet",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Item",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "Location",
                schema: "GuildWars2.Data",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item",
                columns: new[] { "UserID", "ItemID", "SkinID", "StatID", "Date" });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryValue",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Delta = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryValue", x => new { x.UserID, x.CategoryID, x.Date });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "GuildWars2.Data");

            migrationBuilder.DropTable(
                name: "CategoryValue",
                schema: "GuildWars2.Data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Wallet",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Item",
                newName: "CreationDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item",
                columns: new[] { "UserID", "ItemID", "SkinID", "StatID" });
        }
    }
}
