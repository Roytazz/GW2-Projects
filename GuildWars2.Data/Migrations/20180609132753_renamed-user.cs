using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class renameduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountName",
                schema: "GuildWars2.UserData",
                table: "User",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "GuildWars2.UserData",
                table: "User",
                newName: "AccountName");
        }
    }
}
