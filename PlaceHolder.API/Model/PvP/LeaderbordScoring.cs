using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class LeaderboardScoring
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ordering")]
        public string Ordering { get; set; }
    }
}