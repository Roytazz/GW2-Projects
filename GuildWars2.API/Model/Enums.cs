using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace GuildWars2.API.Model
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
        Guardian,
        Warrior,
        Revenant,
        Ranger,
        Engineer,
        Thief,
        Elementalist,
        Mesmer,
        Necromancer
    }

    public enum EliteSpecialization
    {
        Dragonhunter,
        Berserker,
        Herald,
        Druid,
        Scrapper,
        Daredevil,
        Tempest,
        Chronomancer,
        Reaper
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
        Enrichment,
        Infusion,
        Utility,
        Agony,
        Defense,
        Offense
    }

    public enum WvWColor
    {
        Red,
        Blue,
        Green,
        Neutral
    }

    public enum WvWMapType {
        Center,     //EB
        BlueHome,  
        RedHome,
        GreenHome,
        ObsidianSanctum,
        EdgeOfTheMists,
    }

    public enum WvWObjectiveType { 
        Camp,
        Castle,
        Keep,
        Mercenary,
        Tower,
        Ruins,
        Resource,
        Generic,
        Spawn
    }
}