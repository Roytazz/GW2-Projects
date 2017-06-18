namespace GuildWars2.GuildInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        User = c.String(),
                        Type = c.Int(nullable: false),
                        Operation = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Coins = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        MOTD = c.String(),
                        InvitedBy = c.String(),
                        KickedBy = c.String(),
                        ChangedBy = c.String(),
                        OldRank = c.String(),
                        NewRank = c.String(),
                        UpgradeID = c.String(),
                        RecipeID = c.String(),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogEntries");
        }
    }
}
