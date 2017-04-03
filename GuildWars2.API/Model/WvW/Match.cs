using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Model.WvW
{
    public class Match
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("worlds")]
        public Dictionary<WvWColor, int> Worlds { get; set; }

        [JsonProperty("all_worlds")]
        public Dictionary<WvWColor, List<int>> AllWorlds { get; set; }
    }
}
