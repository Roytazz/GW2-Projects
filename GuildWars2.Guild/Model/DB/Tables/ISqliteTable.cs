using GuildWars2Guild.Classes;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GuildWars2Guild.Model.DB.Tables
{
    public interface ISqliteTable<T> {
        string Name { get; }
        SqliteTable CreateTable();
        IEnumerable<Dictionary<string, object>> Seed();
        Dictionary<string, object> ToDictionary(T entity);
    }

    public abstract class SqliteTable<T>
    {
        public Dictionary<string, object> ToDictionary(T entity) {
            return Reflection.CopyProps(entity);
        }
    }
}
