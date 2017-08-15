using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.REST.Data.Migrations
{
    public partial class addeddiffManualBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ManualEntry",
                table: "ItemDifference",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ManualEntry",
                table: "CurrencyDifference",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManualEntry",
                table: "ItemDifference");

            migrationBuilder.DropColumn(
                name: "ManualEntry",
                table: "CurrencyDifference");
        }
    }
}
