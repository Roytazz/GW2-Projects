namespace GuildWars2.GuildInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        RankName = c.String(),
                        Joined = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
