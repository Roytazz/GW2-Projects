using GuildWars2.GuildInfo.Models;
using System;
using System.Collections.Generic;

namespace GuildWars2.GuildInfo.Sheets
{
    static class RangeCreator
    {
        public static string Range<T>(List<T> items) where T : ISheetItem {
            if(items.Count > 0)
                return $"A1:{GetColumnName(items[0].Header().Count - 1)}{items.Count + 1}";

            return string.Empty;
        }

        public static string EndlessRange<T>() where T : ISheetItem {
            return $"A1:{GetColumnName(Activator.CreateInstance<T>().Header().Count - 1)}";
        }

        static string GetColumnName(int index) {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = string.Empty;
            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];
            return value;
        }
    }
}