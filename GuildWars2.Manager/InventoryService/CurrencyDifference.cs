using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Manager.InventoryService
{
    public class CurrencyDifference
    {
        [JsonProperty("currencyId")]
        public int CurrencyID { get; set; }

        public int Count { get; set; }

        public int Difference { get; set; }
    }
}