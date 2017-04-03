using GuildWars2.GuildInfo.Models;
using System.Collections.Generic;

namespace GuildWars2.GuildInfo.Sheets
{
    static class RangeCreator
    {
        public static string CreateRange<T>(List<T> objs) where T : ISheetItem {
            var result = $"A1:{GetColumnName(objs[0].Flatten().Count - 1)}{objs.Count + 1}";
            return result;
        }

        static string GetColumnName(int index) {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";
            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];
            return value;
        }
    }
}