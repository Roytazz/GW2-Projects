using GuildWars2Guild.Classes.Database.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GuildWars2Guild.Classes.Database
{
    internal abstract class BaseDbManager<T, K> where T : ISqliteTable<K>, new()
                                                where K : new()
    {
        private static string DATA_SOURCE = "FGCT_DATABASE.sqlite";

        protected static void AddEntity(K entity) {
            using(SQLiteConnection conn = GetDatabase()) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();

                    SqliteHelper helper = new SqliteHelper(cmd);

                    var type = new T();
                    if(!helper.IsTableCreated(type.Name)) {
                        helper.CreateTable(type.CreateTable());
                    }

                    helper.Insert(type.Name, type.ToDictionary(entity));

                    //conn.Close();
                }
            }
        }

        protected static void AddEntity(IEnumerable<K> entities) {
            using(SQLiteConnection conn = GetDatabase()) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();

                    SqliteHelper helper = new SqliteHelper(cmd);

                    if(entities.Count() <= 0)
                        return;

                    var type = new T();
                    if(!helper.IsTableCreated(type.Name)) {
                        helper.CreateTable(type.CreateTable());
                    }

                    foreach(var entity in entities) {
                        helper.Insert(type.Name, type.ToDictionary(entity));
                    }

                    //conn.Close();
                }
            }
        }

        protected static IEnumerable<K> GetEntity() {
            DataTable table;

            using(SQLiteConnection conn = GetDatabase()) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();

                    var entity = new T();
                    SqliteHelper helper = new SqliteHelper(cmd);

                    if(!helper.IsTableCreated(entity.Name)) {
                        helper.CreateTable(entity.CreateTable());
                    }
                    table = helper.SelectAll(entity.Name);

                    //conn.Close();
                }
            }
            return ConvertTable(table);
        }

        private static bool IsDatabaseCreated() => File.Exists(DATA_SOURCE);

        private static SQLiteConnection GetDatabase() {
            if(!IsDatabaseCreated())
                SQLiteConnection.CreateFile(DATA_SOURCE);

            return new SQLiteConnection($"data source={DATA_SOURCE}");
        }

        public BaseDbManager() { }

        public BaseDbManager(string dbName) {
            if(!string.IsNullOrEmpty(dbName))
                DATA_SOURCE = dbName;
        }
        
        private static IEnumerable<K> ConvertTable(DataTable table) {
            try {
                List<K> list = new List<K>();

                foreach(var row in table.AsEnumerable()) {
                    K obj = new K();

                    foreach(var prop in obj.GetType().GetProperties()) {
                        try {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch {
                return null;
            }
        }
    }
}
