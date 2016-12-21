using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Mechanics
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
