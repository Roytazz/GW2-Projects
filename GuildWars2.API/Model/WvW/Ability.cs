using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class Ability
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("ranks")]
        public List<AbilityRank> Ranks { get; set; }
    }
}
