using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Guild.Classes.Database.Tables
{
    interface ISqliteTable<T> {
        string Name { get; }
        SqliteTable CreateTable();
        Dictionary<string, object> ToDictionary(T entity);
    }
}
