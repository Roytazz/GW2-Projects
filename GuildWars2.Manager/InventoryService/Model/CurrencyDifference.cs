using GuildWars2.API.Model.Commerce;
using Newtonsoft.Json;

namespace GuildWars2.Manager.InventoryService
{
    public class CurrencyDifference
    {
        [JsonProperty("currencyId")]
        public int CurrencyID { get; set; }

        public int Count { get; set; }

        public int Difference { get; set; }

        public ItemPrice Value { get; set; }
    }
}