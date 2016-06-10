using GuildWars2DB.Model.Tables;
using System.Configuration;
using System.Data.SQLite;
using System.IO;

namespace GuildWars2DB.Model
{
    public class BaseDbManager
    {
        public static void InitializeDatabase() {
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();
                    var helper = new SqliteHelper(cmd);

                    helper.CreateTable(new GuildLogTable().CreateTable());
                    //helper.CreateTable(new AnotherTable().CreateTable());
                    //helper.CreateTable(new AndAnotherTable().CreateTable());
                }
            }
        }

        protected static string ConnectionString
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["Gw2DbContext"].ConnectionString;
                var dbName = connectionString.Substring(connectionString.IndexOf('=') + 1);

                if(!File.Exists(dbName)) {
                    SQLiteConnection.CreateFile(dbName);
                    InitializeDatabase();
                }

                return connectionString;
            }
        }
    }
}