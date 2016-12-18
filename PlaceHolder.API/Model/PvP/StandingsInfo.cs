using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class StandingsInfo
    {
        [JsonProperty("total_points")]
        public int TotalPoints { get; set; }

        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("repeats")]
        public int Repeats { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("decay")]
        public int Decay { get; set; }
    }
}