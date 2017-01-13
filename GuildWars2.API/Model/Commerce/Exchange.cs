using Newtonsoft.Json;

namespace GuildWars2API.Model.Commerce
{
    public class Exchange
    {
        [JsonProperty("coins_per_gem")]
        public int CoinsPerGem { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
