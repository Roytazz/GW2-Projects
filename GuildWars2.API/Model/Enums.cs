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
        HeartOfThorns,
        PathOfFire
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
        Merchant,
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
        Firebrand,
        Berserker,
        Spellbreaker,
        Herald,
        Renegade,
        Druid,
        Soulbeast,
        Scrapper,
        Holosmith,
        Daredevil,
        Deadeye,
        Tempest,
        Weaver,
        Chronomancer,
        Mirage,
        Reaper,
        Scourge
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



    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeaponSlot
    {
        [EnumMember(Value = "downed_1")] Downed1,
        [EnumMember(Value = "downed_2")] Downed2,
        [EnumMember(Value = "downed_3")] Downed3,
        [EnumMember(Value = "downed_4")] Downed4,
        [EnumMember(Value = "profession_1")] Profession1,
        [EnumMember(Value = "profession_2")] Profession2,
        [EnumMember(Value = "profession_3")] Profession3,
        [EnumMember(Value = "profession_4")] Profession4,
        [EnumMember(Value = "profession_5")] Profession5,
        Utility,
        Elite,
        Heal,
        [EnumMember(Value = "weapon_1")] Weapon1,
        [EnumMember(Value = "weapon_2")] Weapon2,
        [EnumMember(Value = "weapon_3")] Weapon3,
        [EnumMember(Value = "weapon_4")] Weapon4,
        [EnumMember(Value = "weapon_5")] Weapon5,
        ToolBelt
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
}