using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.SQLite
{
    public class SqliteColumn
    {
        public string ColumnName = "";
        public bool PrimaryKey = false;
        public ColType ColDataType = ColType.Text;
        public bool AutoIncrement = false;
        public bool NotNull = false;
        public string DefaultValue = "";

        public SqliteColumn()
        { }

        public SqliteColumn(string colName)
        {
            ColumnName = colName;
            PrimaryKey = false;
            ColDataType = ColType.Text;
            AutoIncrement = false;
        }

        public SqliteColumn(string colName, ColType colDataType)
        {
            ColumnName = colName;
            PrimaryKey = false;
            ColDataType = colDataType;
            AutoIncrement = false;
        }

        public SqliteColumn(string colName, bool autoIncrement)
        {
            ColumnName = colName;

            if (autoIncrement)
            {
                PrimaryKey = true;
                ColDataType = ColType.Integer;
                AutoIncrement = true;
            }
            else
            {
                PrimaryKey = false;
                ColDataType = ColType.Text;
                AutoIncrement = false;
            }
        }

        public SqliteColumn(string colName, ColType colDataType, bool primaryKey, bool autoIncrement, bool notNull, string defaultValue)
        {
            ColumnName = colName;

            if (autoIncrement)
            {
                PrimaryKey = true;
                ColDataType = ColType.Integer;
                AutoIncrement = true;
            }
            else
            {
                PrimaryKey = primaryKey;
                ColDataType = colDataType;
                AutoIncrement = false;
                NotNull = notNull;
                DefaultValue = defaultValue;
            }
        }
    }
}
