using Newtonsoft.Json;

namespace GuildWars2API.Model.PvP
{
    public class LeaderboardEntry
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}