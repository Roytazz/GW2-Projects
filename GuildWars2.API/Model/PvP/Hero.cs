using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.PvP
{
    public class Hero
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("stats")]
        public Dictionary<HeroStat, int> Stats { get; set; }

        [JsonProperty("skins")]
        public List<HeroSkin> Skins { get; set; }
    }

    public enum HeroStat
    {
        Offense,
        Defense,
        Speed
    }
}
