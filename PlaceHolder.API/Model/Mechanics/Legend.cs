using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Mechanics
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
