using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.PvP
{
    public class HeroSkin
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("unlock_items")]
        public List<int> UnlockItems { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }
    }
}
