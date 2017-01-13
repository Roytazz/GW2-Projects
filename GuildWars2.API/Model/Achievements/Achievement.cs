using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Achievements
{
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

    public enum AchievementType
    {
        Default,
        ItemSet
    }

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
