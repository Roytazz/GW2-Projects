using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Mechanics
{
    public class Legend
    {
        [JsonProperty("id")]
        public LegendType ID { get; set; }

        [JsonProperty("swap")]
        public int Swap { get; set; }

        [JsonProperty("heal")]
        public int Heal { get; set; }

        [JsonProperty("elite")]
        public int Elite { get; set; }

        [JsonProperty("utilities")]
        public List<int> Utilities { get; set; }
    }
}
