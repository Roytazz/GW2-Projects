using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Guild
{
    public class Emblem
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("layers")]
        public List<string> Layers { get; set; }
    }
}
