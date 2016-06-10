using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.SQLite
{
    public class SqliteTable
    {
        public string TableName = "";
        public SqliteColumnList Columns = new SqliteColumnList();

        public SqliteTable()
        { }

        public SqliteTable(string name)
        {
            TableName = name;
        }
    }
}