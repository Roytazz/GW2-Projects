using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GuildWars2.Web.Data.Migrations
{
    public partial class AddedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyCount = table.Column<int>(nullable: false),
                    Charges = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    DamageType = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DurationMS = table.Column<int>(nullable: false),
                    MaxPower = table.Column<int>(nullable: false),
                    MinPower = table.Column<int>(nullable: false),
                    MiniPetID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NoSellOrSort = table.Column<bool>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false),
                    SecondarySuffixItemID = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Suffix = table.Column<string>(nullable: true),
                    SuffixItemID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UnlockType = table.Column<int>(nullable: false),
                    WeightClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChatLink = table.Column<string>(nullable: true),
                    DefaultSkin = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DetailsID = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rarity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    VendorValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_ItemDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "ItemDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_DetailsID",
                table: "Item",
                column: "DetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemDetails");
        }
    }
}
