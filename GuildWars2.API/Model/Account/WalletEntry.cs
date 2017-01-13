using Newtonsoft.Json;

namespace GuildWars2API.Model.Account
{
    public class WalletEntry
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
