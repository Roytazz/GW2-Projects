using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GuildWars2.API.Model.Mechanics
{
    public class Skill : ClassMechanic
    {
        [JsonProperty("chat_link")]
        public string ChatLink { get; set; }

        [JsonProperty("type")]
        public SkillType Type { get; set; }

        [JsonProperty("weapon_type")]
        public Weapon WeaponType { get; set; }

        [JsonProperty("professions")]
        public List<Profession> Professions { get; set; }

        [JsonProperty("slot")]
        public WeaponSlot Slot { get; set; }

        [JsonProperty("categories")]
        public List<SkillCategory> Categories { get; set; }    

        [JsonProperty("attunement")]
        public string Attunement { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("dual_wield")]
        public string DualWield { get; set; }

        [JsonProperty("flip_skill")]
        public int FlipSkill { get; set; }

        [JsonProperty("initiative")]
        public int Initiative { get; set; }

        [JsonProperty("next_chain")]
        public int NextChain { get; set; }

        [JsonProperty("prev_chain")]
        public int PreviousChain { get; set; }

        [JsonProperty("transform_skills")]
        public List<int> TransformSkills { get; set; }

        [JsonProperty("bundle_skills")]
        public List<int> BundleSkills { get; set; }

        [JsonProperty("toolbelt_skill")]
        public int ToolbeltSkill { get; set; }
    }

    public enum SkillFactType
    {
        AttributeAdjust,
        Buff,
        BuffConversion,
        ComboField,
        ComboFinisher,
        Damage,
        Distance,
        Duration,
        Heal,
        HealingAdjust,
        NoData,
        Number,
        Percent,
        PrefixedBuff,
        Radius,
        Range,
        Recharge,
        StunBreak,
        Time,
        Unblockable
    }

    public enum SkillCategory
    {
        Glyph, Signet,
        Cantrip, Conjure,
        Arcane, Kit,
        Gadget, Turret,
        Elixir, Shout,
        Symbol, Virtue,
        SpiritWeapon,
        Consecration, Ward,
        Meditation, Clone,
        Phantasm, Manipulation,
        Glamour, Mantra,
        Well, Minion,
        Corruption, Spectral,
        Mark, Trap,
        Survival, Spirit,
        Deception, StealthAttack,
        DualWield, Trick,
        Venom, Burst,
        Physical, Stance,
        Banner, LegendaryDwarf,
        LegendaryDragon, LegendaryDemon,
        LegendaryAssassin, Overload,
        Rage, PrimalBurst,
        Gyro, CelestialAvatar
    }
}
