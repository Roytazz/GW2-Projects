using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class deleteditemlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                schema: "GuildWars2.UserData",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location",
                schema: "GuildWars2.UserData",
                table: "Item",
                nullable: false,
                defaultValue: 0);
        }
    }
}
