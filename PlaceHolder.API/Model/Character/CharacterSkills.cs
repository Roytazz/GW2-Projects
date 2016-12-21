using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class CharacterSkills
    {
        [JsonProperty("heal")]
        public int? Heal { get; set; }

        [JsonProperty("utilities")]
        public List<int?> Utilities { get; set; }

        [JsonProperty("elite")]
        public int? Elite { get; set; }

        [JsonProperty("pets")]
        public Dictionary<PetFamily, List<int>> Pets { get; set; }

        [JsonProperty("legends")]
        public List<LegendType> Legends { get; set; }
    }

    public enum PetFamily {
        Aquatic,
        Amphibious,
        Terrestrial
    }
}