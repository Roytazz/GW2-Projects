using Newtonsoft.Json;

namespace GuildWars2.API.Model.WvW
{
    public class AbilityRank
    {
        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("effect")]
        public string Effect { get; set; }
    }
}
