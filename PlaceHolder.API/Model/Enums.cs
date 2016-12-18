using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model
{
    public enum EntityBinding
    {
        Account,
        Character
    }

    public enum ItemRarity
    {
        Junk,
        Basic,
        Fine,
        Masterwork,
        Rare,
        Exotic,
        Ascended,
        Legendary
    }

    public enum WeightClass
    {
        Clothing,
        Light,
        Medium,
        Heavy
    }

    public enum DamageType
    {
        Physical,
        Fire,
        Lightning,
        Ice,
        Choking
    }

    public enum Access
    {
        None,
        PlayForFree,
        GuildWars2,
        HeartOfThorns
    }

    public enum Discipline
    {
        Armorsmith,
        Artificer,
        Chef,
        Huntsman,
        Jeweler,
        Leatherworker,
        Scribe,
        Tailor,
        Weaponsmith
    }

    public enum Profession
    {
        [JsonProperty("elementalist")] Elementalist,
        [JsonProperty("engineer")] Engineer,
        [JsonProperty("guardian")] Guardian,
        [JsonProperty("mesmer")] Mesmer,
        [JsonProperty("necromancer")] Necromancer,
        [JsonProperty("ranger")] Ranger,
        [JsonProperty("revenant")] Revenant,
        [JsonProperty("thief")] Thief,
        [JsonProperty("warrior")] Warrior
    }
    
    public enum Race
    {
        Asura,
        Charr,
        Human,
        Norn,
        Sylvari
    }

    public enum ItemAttribute
    {
        AgonyResistance,
        BoonDuration,
        ConditionDamage,
        ConditionDuration,
        CritDamage,
        Healing,
        Power,
        Precision,
        Toughness,
        Vitality
    }

    public enum GameType
    {
        [JsonProperty("pve")] PvE,
        [JsonProperty("pvp")] PvP,
        [JsonProperty("wvw")] Wvw,
        [JsonProperty("special")] Special
    }

    public enum PvPMode
    {
        [JsonProperty("ranked")] Ranked,
        [JsonProperty("unranked")] Unranked
    }
}
