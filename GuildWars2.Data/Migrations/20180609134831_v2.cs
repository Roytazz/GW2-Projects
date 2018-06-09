using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildWars2.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dye_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Dye");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Mini_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Mini");

            migrationBuilder.DropForeignKey(
                name: "FK_Skin_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Skin");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Wallet");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_UserID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                newName: "IX_Wallet_AccountID");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "GuildWars2.UserData",
                table: "User",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "GuildWars2.UserData",
                table: "Skin",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "GuildWars2.UserData",
                table: "Mini",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "GuildWars2.UserData",
                table: "Item",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UserID",
                schema: "GuildWars2.UserData",
                table: "Item",
                newName: "IX_Item_AccountID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "GuildWars2.UserData",
                table: "Dye",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "GuildWars2.UserData",
                table: "CategoryValue",
                newName: "AccountID");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "GuildWars2.UserData",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "GuildWars2.UserData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Key_AccountID",
                schema: "GuildWars2.UserData",
                table: "Key",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dye_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Dye",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Item",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Key_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Key",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mini_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Mini",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skin_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Skin",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                column: "AccountID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dye_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Dye");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Key_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Key");

            migrationBuilder.DropForeignKey(
                name: "FK_Mini_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Mini");

            migrationBuilder.DropForeignKey(
                name: "FK_Skin_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Skin");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Account_AccountID",
                schema: "GuildWars2.UserData",
                table: "Wallet");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "GuildWars2.UserData");

            migrationBuilder.DropIndex(
                name: "IX_Key_AccountID",
                schema: "GuildWars2.UserData",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "GuildWars2.UserData",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_AccountID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                newName: "IX_Wallet_UserID");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "GuildWars2.UserData",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Skin",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Mini",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Item",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Item_AccountID",
                schema: "GuildWars2.UserData",
                table: "Item",
                newName: "IX_Item_UserID");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "Dye",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                schema: "GuildWars2.UserData",
                table: "CategoryValue",
                newName: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dye_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Dye",
                column: "UserID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Item",
                column: "UserID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mini_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Mini",
                column: "UserID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skin_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Skin",
                column: "UserID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_User_UserID",
                schema: "GuildWars2.UserData",
                table: "Wallet",
                column: "UserID",
                principalSchema: "GuildWars2.UserData",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
