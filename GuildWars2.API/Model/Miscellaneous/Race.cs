using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Race
    {
        [JsonProperty("id")]
        public Model.Race ID { get; set; }

        [JsonProperty("skills")]
        public List<int> Skills { get; set; }
    }
}
