using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations.DataDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GuildWars2.GW2Data");

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "GuildWars2.GW2Data",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ChatLink = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Rarity = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    VendorValue = table.Column<int>(nullable: false),
                    DefaultSkin = table.Column<int>(nullable: false),
                    Flags = table.Column<string>(nullable: true),
                    GameTypes = table.Column<string>(nullable: true),
                    Restrictions = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.KeyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "GuildWars2.GW2Data");
        }
    }
}
