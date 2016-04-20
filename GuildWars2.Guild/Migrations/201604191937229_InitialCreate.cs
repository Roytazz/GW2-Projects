namespace GuildWars2Guild.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBLogEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LogID = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        User = c.String(),
                        Type = c.String(),
                        ItemID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Coins = c.Int(nullable: false),
                        MOTD = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBLogEntries");
        }
    }
}
