using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Miscellaneous
{
    public class Server
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("population")]
        public PopulationDensity Population { get; set; }
    }

    public enum PopulationDensity
    {
        Low,
        Medium,
        High,
        VeryHigh,
        Full
    }
}
