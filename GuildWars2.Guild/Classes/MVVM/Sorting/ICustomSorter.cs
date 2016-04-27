using System.Collections;
using System.ComponentModel;

namespace GuildWars2Guild.Classes.MVVM.Sorting
{
    public interface ICustomSorter : IComparer
    {
        ListSortDirection SortDirection { get; set; }
    }
}
