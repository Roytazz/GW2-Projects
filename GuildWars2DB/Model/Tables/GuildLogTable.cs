using GuildWars2API.Model.Guild;
using GuildWars2DB.Classes;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GuildWars2DB.Model.Tables
{
    public class GuildLogTable : ISqliteTable<LogEntry>
    {
        public string Name { get { return "GuildLog"; } }

        public SqliteTable CreateTable() {
            SqliteTable table = new SqliteTable(Name);
            table.Columns.Add(new SqliteColumn("ID", ColType.Integer, true, true, true, "-1"));
            table.Columns.Add(new SqliteColumn("LogID", ColType.Integer));
            table.Columns.Add(new SqliteColumn("Time", ColType.DateTime));
            table.Columns.Add(new SqliteColumn("User", ColType.Text));
            table.Columns.Add(new SqliteColumn("Type", ColType.Text));
            table.Columns.Add(new SqliteColumn("Operation", ColType.Text));
            table.Columns.Add(new SqliteColumn("Count", ColType.Integer));
            table.Columns.Add(new SqliteColumn("Coins", ColType.Integer));
            table.Columns.Add(new SqliteColumn("ItemID", ColType.Integer));
            table.Columns.Add(new SqliteColumn("MOTD", ColType.Text));
            table.Columns.Add(new SqliteColumn("InvitedBy", ColType.Text));
            table.Columns.Add(new SqliteColumn("KickedBy", ColType.Text));
            table.Columns.Add(new SqliteColumn("ChangedBy", ColType.Text));
            table.Columns.Add(new SqliteColumn("OldRank", ColType.Text));
            table.Columns.Add(new SqliteColumn("NewRank", ColType.Text));
            table.Columns.Add(new SqliteColumn("UpgradeID", ColType.Text));
            table.Columns.Add(new SqliteColumn("Action", ColType.Text));

            return table;
        }

        public Dictionary<string, object> ToDictionary(LogEntry entity) {
            return Reflection.CopyProps(entity);
        }
    }
}
