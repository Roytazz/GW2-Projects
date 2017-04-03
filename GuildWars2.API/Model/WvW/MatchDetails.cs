using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class MatchDetails : Match
    {
        [JsonProperty("scores")]
        public Dictionary<WvWColor, int> Scores { get; set; }

        [JsonProperty("ratings")]
        public Dictionary<WvWColor, double> Ratings { get; set; }

        [JsonProperty("victory_points")]
        public Dictionary<WvWColor, int> VictoryPoints { get; set; }

        [JsonProperty("maps")]
        public List<Map> Maps { get; set; }
    }
}
