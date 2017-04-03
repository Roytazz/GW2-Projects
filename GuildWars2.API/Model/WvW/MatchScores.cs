using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class MatchScores
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("scores")]
        public Dictionary<WvWColor, int> Scores { get; set; }

        [JsonProperty("maps")]
        public List<Map> Maps { get; set; }
    }
}
