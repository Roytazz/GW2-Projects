using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Dungeon
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("paths")]
        public List<Dungeon> Paths { get; set; }

        [JsonIgnore]
        public List<string> PathNames {
            get {
                return Paths.Select(p => p.ID).ToList();
            }
        }
    }
}
