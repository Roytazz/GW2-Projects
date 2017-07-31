using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GuildWars2.REST.Data.Migrations
{
    public partial class addedtrend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemDifference",
                newName: "ItemID");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "CurrencyDifference",
                newName: "CurrencyID");

            migrationBuilder.CreateTable(
                name: "CurrencyTrend",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountName = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTrend", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTrend",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountName = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTrend", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyTrend");

            migrationBuilder.DropTable(
                name: "ItemTrend");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "ItemDifference",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "CurrencyID",
                table: "CurrencyDifference",
                newName: "CurrencyId");
        }
    }
}
