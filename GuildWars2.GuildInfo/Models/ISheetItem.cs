using GuildWars2.API.Model.Guild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.GuildInfo.Models
{
    interface ISheetItem
    {
        IList<object> Header();
        IList<object> Flatten();
    }
}
