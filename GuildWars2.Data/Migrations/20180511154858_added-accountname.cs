using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class addedaccountname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User",
                columns: new[] { "ID", "AccountName" });

            migrationBuilder.CreateTable(
                name: "Key",
                schema: "GuildWars2.Data",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    APIKey = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => new { x.UserID, x.APIKey });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Key",
                schema: "GuildWars2.Data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountName",
                schema: "GuildWars2.Data",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "GuildWars2.Data",
                table: "User",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "GuildWars2.Data",
                table: "User",
                column: "ID");
        }
    }
}
