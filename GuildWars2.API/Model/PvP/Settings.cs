using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.PvP
{
    public class LeaderboardSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("scoring")]
        public string Scoring { get; set; }

        [JsonProperty("tiers")]
        public List<LeaderboardTier> Tiers { get; set; }
    }
}