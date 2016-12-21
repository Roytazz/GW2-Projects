using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Mechanics
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

    public enum SkillType
    {
        Bundle,
        Elite,
        Heal,
        Profession,
        Utility,
        Weapon,
        ToolBelt,
        Monster
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
        Time,
        Unblockable
    }

    public enum WeaponSlot
    {
        Downed_1,
        Downed_2,
        Downed_3,
        Downed_4,
        Profession_1,
        Profession_2,
        Profession_3,
        Profession_4,
        Profession_5,
        Utility,
        Elite,
        Heal,
        Weapon_1,
        Weapon_2,
        Weapon_3,
        Weapon_4,
        Weapon_5,
        ToolBelt
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
