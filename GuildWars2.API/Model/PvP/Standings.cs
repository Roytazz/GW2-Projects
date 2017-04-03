using Newtonsoft.Json;

namespace GuildWars2.API.Model.PvP
{
    public class Standings
    {
        [JsonProperty("current")]
        public StandingsInfo Current { get; set; }

        [JsonProperty("best")]
        public StandingsInfo Best { get; set; }

        [JsonProperty("season_id")]
        public string SeasonID { get; set; }
    }
}
