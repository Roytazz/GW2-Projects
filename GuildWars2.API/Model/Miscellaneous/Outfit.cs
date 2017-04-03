using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Outfit
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("unlock_items")]
        public List<int> UnlockItems { get; set; }
    }
}
