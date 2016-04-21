namespace GuildWars2Guild.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DBLogEntries", "KickedBy", c => c.String());
            AddColumn("dbo.DBLogEntries", "ChangedBy", c => c.String());
            AddColumn("dbo.DBLogEntries", "OldRank", c => c.String());
            AddColumn("dbo.DBLogEntries", "NewRank", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DBLogEntries", "NewRank");
            DropColumn("dbo.DBLogEntries", "OldRank");
            DropColumn("dbo.DBLogEntries", "ChangedBy");
            DropColumn("dbo.DBLogEntries", "KickedBy");
        }
    }
}
