using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace GuildWars2API.Model
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

    [JsonConverter(typeof(StringEnumConverter))]
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
        Weaponsmith,
        [EnumMember(Value = "Mystic Forge")] MysticForge
    }

    public enum Profession
    {
        Elementalist,
        Engineer,
        Guardian,
        Mesmer,
        Necromancer,
        Ranger,
        Revenant,
        Thief,
        Warrior
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
        Vitality,
        None
    }

    public enum GameType
    {
        PvE,
        PvP,
        PvPLobby,
        Wvw,
        Fractals,
        Special,
        Activity,
        Dungeon
    }

    public enum Weapon
    {
        Axe,
        Dagger,
        Mace,
        Pistol,
        Sword,
        Scepter,
        Focus,
        Shield,
        Torch,
        Warhorn,
        Greatsword,
        Hammer,
        Longbow,
        Rifle,
        Shortbow,
        Staff,
        Speargun,
        Spear,
        Trident,
        None
    }

    public enum LegendType
    {
        Legend1,
        Legend2,
        Legend3,
        Legend4,
        Legend5,
        Legend6
    }
    
    public enum InfusionUpgradeFlag
    {
        Defense,
        Offense,
        Utility,
        Agony
    }
}