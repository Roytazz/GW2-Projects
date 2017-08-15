using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.REST.Data.Migrations
{
    public partial class stable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infusion_ItemDetails_ItemDetailsID",
                table: "Infusion");

            migrationBuilder.DropIndex(
                name: "IX_Infusion_ItemDetailsID",
                table: "Infusion");

            migrationBuilder.DropColumn(
                name: "ItemDetailsID",
                table: "Infusion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemDetailsID",
                table: "Infusion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infusion_ItemDetailsID",
                table: "Infusion",
                column: "ItemDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Infusion_ItemDetails_ItemDetailsID",
                table: "Infusion",
                column: "ItemDetailsID",
                principalTable: "ItemDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
