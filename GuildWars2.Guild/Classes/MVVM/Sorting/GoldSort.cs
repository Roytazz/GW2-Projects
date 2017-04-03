using GuildWars2.Guild.Model;
using System.ComponentModel;

namespace GuildWars2.Guild.Classes.MVVM.Sorting
{
    public class GoldSort : ICustomSorter
    {
        public GoldSort() { }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object x, object y) {
            if(x is GoldEntry && y is GoldEntry) {
                int result = (x as GoldEntry).Value.CompareTo((y as GoldEntry).Value);
                return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
            }
            return 0;
        }
    }
}
