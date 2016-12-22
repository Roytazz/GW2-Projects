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

    public enum FinisherType
    {
        Blast,
        Leap,
        Projectile,
        Whirl
    }

    public enum DamageType
    {
        Physical,
        Fire,
        Lightning,
        Ice,
        Choking
    }

    public enum FieldType
    {
        Air,
        Dark,
        Fire,
        Ice,
        Light,
        Lightning,
        Poison,
        Smoke,
        Ethereal,
        Water
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
        Special,
        Activity,
        Dungeon
    }

    public enum PvPMode
    {
        Ranked,
        Unranked
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