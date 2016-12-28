using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class LeaderboardTier
    {
        [JsonProperty("range")]
        public List<double> Range { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }
    }
}