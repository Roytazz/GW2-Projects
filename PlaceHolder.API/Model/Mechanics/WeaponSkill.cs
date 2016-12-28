using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeaponSkillbarSlot  
    {
        [EnumMember(Value = "weapon_1")] Weapon1,
        [EnumMember(Value = "weapon_2")] Weapon2,
        [EnumMember(Value = "weapon_3")] Weapon3,
        [EnumMember(Value = "weapon_4")] Weapon4,
        [EnumMember(Value = "weapon_5")] Weapon5,
    }
}