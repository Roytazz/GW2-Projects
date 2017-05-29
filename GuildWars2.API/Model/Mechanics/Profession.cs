using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Mechanics
{
    public class ProfessionInfo
    {
        [JsonProperty("id")]
        public Profession ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("big_icon")]
        public string BigIcon { get; set; }

        [JsonProperty("specializations")]
        public List<int> Specializations { get; set; }

        [JsonProperty("training")]
        public List<TrainingInfo> Training { get; set; }

        [JsonProperty("weapons")]
        public Dictionary<Weapon, ProfessionWeapon> Weapons { get; set; }

        [JsonProperty("skills")]
        public List<ProfessionSkill> Skills { get; set; } 
    }
}
