using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Mechanics
{
    public class Trait : ClassMechanic
    {
        [JsonProperty("specialization")]
        public int Specialization { get; set; }

        [JsonProperty("tier")]
        public TraitTier Tier { get; set; }

        [JsonProperty("slot")]
        public TraitSlot Slot { get; set; }

        [JsonProperty("skills")]
        public List<Skill> Skills { get; set; }
    }

    public enum TraitSlot
    {
        Major,
        Minor
    }

    public enum TraitTier
    {
        Elite,
        Adept,
        Master,
        Grandmaster
    }
}
