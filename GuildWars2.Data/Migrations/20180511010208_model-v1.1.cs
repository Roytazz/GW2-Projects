using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildWars2.Data.Migrations
{
    public partial class modelv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                schema: "GuildWars2.Data",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryValue",
                schema: "GuildWars2.Data",
                table: "CategoryValue");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Skin",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Dye",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "Wallet",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "Item",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "CategoryValue",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                schema: "GuildWars2.Data",
                table: "Wallet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryValue",
                schema: "GuildWars2.Data",
                table: "CategoryValue",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                schema: "GuildWars2.Data",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryValue",
                schema: "GuildWars2.Data",
                table: "CategoryValue");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "CategoryValue");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Skin",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Dye",
                newName: "CreationDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                schema: "GuildWars2.Data",
                table: "Wallet",
                columns: new[] { "UserID", "CurrencyID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "GuildWars2.Data",
                table: "Item",
                columns: new[] { "UserID", "ItemID", "SkinID", "StatID", "Date" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryValue",
                schema: "GuildWars2.Data",
                table: "CategoryValue",
                columns: new[] { "UserID", "CategoryID", "Date" });
        }
    }
}
