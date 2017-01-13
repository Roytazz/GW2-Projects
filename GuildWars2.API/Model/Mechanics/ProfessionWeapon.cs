using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Mechanics
{
    public class ProfessionWeapon
    {
        [JsonProperty("specialization")]
        public int Specialization { get; set; }

        [JsonProperty("skills")]
        public List<WeaponSkill> Skills { get; set; }
    }
}