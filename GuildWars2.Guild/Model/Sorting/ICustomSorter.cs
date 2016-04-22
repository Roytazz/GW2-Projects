using System.Collections;
using System.ComponentModel;

namespace GuildWars2Guild.Model.Sorting
{
    public interface ICustomSorter : IComparer
    {
        ListSortDirection SortDirection { get; set; }
    }
}
