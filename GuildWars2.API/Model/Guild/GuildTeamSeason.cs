using Newtonsoft.Json;

namespace GuildWars2API.Model.Guild
{
    public class GuildTeamSeason
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}