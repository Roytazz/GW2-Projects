namespace GuildWars2Guild.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertTypeChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LogEntries", newName: "DBLogEntries");
            AddColumn("dbo.DBLogEntries", "LogID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DBLogEntries", "LogID");
            RenameTable(name: "dbo.DBLogEntries", newName: "LogEntries");
        }
    }
}
