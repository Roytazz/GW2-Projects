using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class Map
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("type")]
        public WvWMapType Type { get; set; }    

        [JsonProperty("scores")]
        public Dictionary<WvWColor, int> Scores { get; set; }

        public List<MapBonus> Bonuses { get; set; }

        [JsonProperty("kills")]
        public Dictionary<WvWColor, int> Kills { get; set; }

        [JsonProperty("deaths")]
        public Dictionary<WvWColor, int> Deaths { get; set; }

        [JsonProperty("objectives")]
        public List<Objective> Objectives { get; set; }
    }
}
