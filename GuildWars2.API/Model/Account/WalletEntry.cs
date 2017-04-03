using Newtonsoft.Json;

namespace GuildWars2.API.Model.Account
{
    public class WalletEntry
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
