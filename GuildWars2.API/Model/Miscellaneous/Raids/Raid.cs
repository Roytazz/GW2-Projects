using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Raid
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("wings")]
        public List<RaidWing> Wings { get; set; }
    }
}
