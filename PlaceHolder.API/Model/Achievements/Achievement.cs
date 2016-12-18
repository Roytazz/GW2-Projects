using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Achievements
{
    // GET /v2/achievements?id=2
    public class Achievement
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("locked_text")]
        public string LockedText { get; set; }

        [JsonProperty("type")]
        public AchievementType Type { get; set; }
        
        [JsonProperty("flags")]
        public List<AchievementFlag> Flags { get; set; }

        [JsonProperty("tiers")]
        public List<Tier> Tiers { get; set; }

        [JsonProperty("rewards")]
        public List<Reward> Rewards { get; set; }

        [JsonProperty("bits")]
        public List<ProgressBit> Bits { get; set; }

        [JsonProperty("prerequisites")]
        public List<int> Prerequisites { get; set; }

        [JsonProperty("point_cap")]
        public int PointsCap { get; set; }

    }


    /// <summary>
    /// Default - A default achievement
    /// ItemSet - Achievement is linked to Collections
    /// </summary>
    public enum AchievementType
    {
        Default,
        ItemSet
    }

    /// <summary>
    /// Pvp - can only get progress in PvP or WvW
    /// CategoryDisplay - is a meta achievement
    /// MoveToTop - affects in-game UI collation
    /// IgnoreNearlyComplete - doesn't appear in the "nearly complete" UI
    /// Repeatable - can be repeated multiple times
    /// </summary>
    public enum AchievementFlag
    {
        Pvp,
        CategoryDisplay,
        MoveToTop,
        IgnoreNearlyComplete,
        Repeatable,
        RequiresUnlock,
        Hidden
    }
}
