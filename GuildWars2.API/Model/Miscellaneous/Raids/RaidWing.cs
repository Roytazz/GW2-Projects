using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class RaidWing
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("events")]
        public List<RaidEvent> Events { get; set; }
    }
}
