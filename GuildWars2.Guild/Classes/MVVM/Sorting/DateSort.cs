using GuildWars2API.Model.Guild;
using System.ComponentModel;

namespace GuildWars2Guild.Classes.MVVM.Sorting
{
    public class DateSort : ICustomSorter
    {
        public DateSort() { }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object x, object y) {
            if(x is LogEntry && y is LogEntry) {
                int result = (x as LogEntry).Time.CompareTo((y as LogEntry).Time);
                return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
            }
            return 0;
        }
    }
}
