using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Mechanics
{
    public class WeaponSkill
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("slot")]
        public WeaponSkillbarSlot Slot { get; set; }

        [JsonProperty("offhand")]
        public string Offhand { get; set; }

        [JsonProperty("attunement")]
        public string Attunement { get; set; }
    }

    public enum WeaponSkillbarSlot
    {
        Weapon_1,
        Weapon_2,
        Weapon_3,
        Weapon_4,
        Weapon_5,
    }
}