namespace GuildWars2Guild.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandedLogEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DBLogEntries", "Operation", c => c.String());
            AddColumn("dbo.DBLogEntries", "UpgradeID", c => c.String());
            AddColumn("dbo.DBLogEntries", "InvitedBy", c => c.String());
            AddColumn("dbo.DBLogEntries", "Action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DBLogEntries", "Action");
            DropColumn("dbo.DBLogEntries", "InvitedBy");
            DropColumn("dbo.DBLogEntries", "UpgradeID");
            DropColumn("dbo.DBLogEntries", "Operation");
        }
    }
}
