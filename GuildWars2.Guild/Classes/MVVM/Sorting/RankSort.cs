using GuildWars2.API.Model.Guild;
using GuildWars2.Guild.Classes.Resources;
using GuildWars2.Guild.Model;
using System.ComponentModel;

namespace GuildWars2.Guild.Classes.MVVM.Sorting
{
    class RankSort : ICustomSorter
    {
        public RankSort() { }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object x, object y) {
            if(x is OrderEntry && y is OrderEntry) {
                    int result = (x as OrderEntry).Order.CompareTo((y as OrderEntry).Order);
                    return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
            }
            if(x is LogEntry && y is LogEntry) {
                var rankX = ResourceProvider.Instance.GetResource<Rank>((x as LogEntry).OldRank).GetAwaiter().GetResult();
                var rankY = ResourceProvider.Instance.GetResource<Rank>((y as LogEntry).OldRank).GetAwaiter().GetResult();
                if(rankX != null && rankY != null) {
                    int result = rankX.Order.CompareTo(rankY.Order);
                    return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
                }
            }
            return 0;
        }
    }

    class NewRankSort : ICustomSorter
    {
        public NewRankSort() { }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object x, object y) {
            if(x is LogEntry && y is LogEntry) {
                var rankX = ResourceProvider.Instance.GetResource<Rank>((x as LogEntry).NewRank).GetAwaiter().GetResult();
                var rankY = ResourceProvider.Instance.GetResource<Rank>((y as LogEntry).NewRank).GetAwaiter().GetResult();
                if(rankX != null && rankY != null) {
                    int result = rankX.Order.CompareTo(rankY.Order);
                    return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
                }
            }
            return 0;
        }
    }

    class OldRankSort : ICustomSorter
    {
        public OldRankSort() { }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object x, object y) {
            if(x is LogEntry && y is LogEntry) {
                var rankX = ResourceProvider.Instance.GetResource<Rank>((x as LogEntry).OldRank).GetAwaiter().GetResult();
                var rankY = ResourceProvider.Instance.GetResource<Rank>((y as LogEntry).OldRank).GetAwaiter().GetResult();
                if(rankX != null && rankY != null) {
                    int result = rankX.Order.CompareTo(rankY.Order);
                    return result * (SortDirection == ListSortDirection.Descending ? 1 : -1);
                }
            }
            return 0;
        }
    }
}
