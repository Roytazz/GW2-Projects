using System.Collections.Generic;

namespace GuildWars2.GuildInfo.Models
{
    interface ISheetItem
    {
        IList<object> Header();
        IList<object> Flatten();
        void Parse(IList<object> values);
    }
}
