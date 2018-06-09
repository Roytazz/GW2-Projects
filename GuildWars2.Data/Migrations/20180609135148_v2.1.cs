using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CategoryValue_AccountID",
                schema: "GuildWars2.UserData",
                table: "CategoryValue",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryValue_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "CategoryValue",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryValue_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "CategoryValue");

            migrationBuilder.DropIndex(
                name: "IX_CategoryValue_AccountID",
                schema: "GuildWars2.UserData",
                table: "CategoryValue");
        }
    }
}
