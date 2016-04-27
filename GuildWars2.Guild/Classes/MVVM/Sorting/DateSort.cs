using GuildWars2Guild.Model;
using System.ComponentModel;

namespace GuildWars2Guild.Classes.MVVM.Sorting
{
    public class DateSort : ICustomSorter
    {
        public DateSort() { }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object x, object y) {
            if(x is GoldEntry && y is GoldEntry) {
                int result = (x as GoldEntry).Time.CompareTo((y as GoldEntry).Time);
                return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
            }
            return 0;
        }
    }
}
