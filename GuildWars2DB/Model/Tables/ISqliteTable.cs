using System.Collections.Generic;
using System.Data.SQLite;

namespace GuildWars2DB.Model.Tables
{
    public interface ISqliteTable<T> {
        string Name { get; }
        SqliteTable CreateTable();
        Dictionary<string, object> ToDictionary(T entity);
    }
}
