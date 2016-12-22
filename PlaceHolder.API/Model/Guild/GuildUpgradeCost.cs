using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Guild
{
    public class GuildUpgradeCost
    {
        [JsonProperty("type")]
        public GuildUpgradeCostType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("item_id")]
        public int ItemID { get; set; }
    }

    public enum GuildUpgradeCostType
    {
        Item,
        Collectible,
        Currency
    }
}