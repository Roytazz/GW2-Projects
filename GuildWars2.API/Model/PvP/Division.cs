using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.PvP
{
    public class Division
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("flags")]
        public List<DivisionFlag> Flags { get; set; }

        [JsonProperty("large_icon")]
        public string LargeIcon { get; set; }

        [JsonProperty("small_icon")]
        public string SmallIcon { get; set; }

        [JsonProperty("pip_icon")]
        public string PipIcon { get; set; }

        [JsonProperty("tiers")]
        public List<DivisionTier> Tiers { get; set; }
    }

    public enum DivisionFlag
    {
        CanLosePoints,
        CanLoseTiers,
        Repeatable
    }
}