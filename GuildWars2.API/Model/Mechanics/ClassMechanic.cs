using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Mechanics
{
    public class ClassMechanic
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("facts")]
        public List<Fact> Facts { get; set; }

        [JsonProperty("traited_facts")]
        public List<Fact> TraitedFacts { get; set; }
    }
}
