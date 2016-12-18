using GuildWars2Guild.Classes;
using GuildWars2Guild.Model.DB.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GuildWars2Guild.Model.DB
{
    public class DbManager<T, TTable> where T : new()
                                      where TTable : ISqliteTable<T>, new()
    {
        protected static void Insert(T entity) {
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();
                    var helper = new SqliteHelper(cmd);

                    helper.Insert(new TTable().Name, Reflection.CopyProps(entity));
                }
            }
        }

        protected static void Insert(IEnumerable<T> entities) {
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();
                    var helper = new SqliteHelper(cmd);

                    foreach(var entity in entities) {
                        helper.Insert(new TTable().Name, Reflection.CopyProps(entity));
                    }
                }
            }
        }

        protected static void Delete(T entity) { }

        protected static void Delete(IEnumerable<T> entities) { }

        protected static void Clear() {
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();
                    var helper = new SqliteHelper(cmd);

                    var table = new TTable();
                    helper.DropTable(table.Name);
                    helper.CreateTable(table.CreateTable());
                }
            }
        }

        protected static IEnumerable<T> Select() {
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();
                    var helper = new SqliteHelper(cmd);

                    return ConvertTable(helper.SelectAll(new TTable().Name));
                }
            }
        }

        protected static IEnumerable<T> Select(Expression<Func<T, bool>> predicate) {
            return Select().Where(predicate.Compile());
        }

        protected static IEnumerable<TResult> SelectColumn<TResult>(Expression<Func<T, TResult>> predicate) {
            return Select().Select(predicate.Compile());
        }

        private static IEnumerable<T> ConvertTable(DataTable table) {
            try {
                List<T> list = new List<T>();

                foreach(var row in table.AsEnumerable()) {
                    T obj = new T();

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

        private static void InitializeDatabase() {
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
                using(SQLiteCommand cmd = new SQLiteCommand()) {
                    cmd.Connection = conn;
                    conn.Open();
                    var helper = new SqliteHelper(cmd);
                    
                    var guildLogTable = new GuildLogTable();
                    helper.CreateTable(guildLogTable.CreateTable());
                    foreach(var row in guildLogTable.Seed()) {
                        helper.Insert(guildLogTable.Name, row);
                    }
                }
            }
        }

        private static string ConnectionString
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
