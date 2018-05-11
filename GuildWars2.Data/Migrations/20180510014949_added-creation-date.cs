using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildWars2.Data.Migrations
{
    public partial class addedcreationdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletEntry",
                schema: "GuildWars2.Data",
                table: "WalletEntry");

            migrationBuilder.RenameTable(
                name: "WalletEntry",
                schema: "GuildWars2.Data",
                newName: "Wallet");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Wallet",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DateAcquired",
                schema: "GuildWars2.Data",
                table: "Skin",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "GuildWars2.Data",
                table: "Item",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DateAcquired",
                schema: "GuildWars2.Data",
                table: "Dye",
                newName: "CreationDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                schema: "GuildWars2.Data",
                table: "Wallet",
                columns: new[] { "UserID", "CurrencyID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                schema: "GuildWars2.Data",
                table: "Wallet");

            migrationBuilder.RenameTable(
                name: "Wallet",
                schema: "GuildWars2.Data",
                newName: "WalletEntry");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "WalletEntry",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Skin",
                newName: "DateAcquired");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Item",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "GuildWars2.Data",
                table: "Dye",
                newName: "DateAcquired");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletEntry",
                schema: "GuildWars2.Data",
                table: "WalletEntry",
                columns: new[] { "UserID", "CurrencyID" });
        }
    }
}
