using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class addaccountIdtokey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Key",
                schema: "GuildWars2.UserData",
                table: "Key");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Key",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Key",
                schema: "GuildWars2.UserData",
                table: "Key",
                columns: new[] { "UserID", "APIKey", "AccountID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Key",
                schema: "GuildWars2.UserData",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Key");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Key",
                schema: "GuildWars2.UserData",
                table: "Key",
                columns: new[] { "UserID", "APIKey" });
        }
    }
}
