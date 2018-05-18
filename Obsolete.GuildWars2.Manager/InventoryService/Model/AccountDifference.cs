using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Manager.InventoryService
{
    public class AccountDifference
    {
        public List<ItemStackDifference> Items { get; set; }

        public List<CurrencyDifference> Currencies { get; set; }
    }
}
