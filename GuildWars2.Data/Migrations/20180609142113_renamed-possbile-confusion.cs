using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class renamedpossbileconfusion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Account",
                newName: "AccountGUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountGUID",
                schema: "GuildWars2.UserData",
                table: "Account",
                newName: "AccountID");
        }
    }
}
