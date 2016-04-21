namespace GuildWars2Guild.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyLogs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DBLogEntries", newName: "LogEntries");
            DropColumn("dbo.LogEntries", "LogID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogEntries", "LogID", c => c.Int(nullable: false));
            RenameTable(name: "dbo.LogEntries", newName: "DBLogEntries");
        }
    }
}
