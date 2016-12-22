using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Guild
{
    public class GuildUpgrade
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public GuildUpgradeType Type { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("build_time")]
        public string BuildTime { get; set; }

        [JsonProperty("required_level")]
        public int RequiredLevel { get; set; }

        [JsonProperty("experience")]
        public int Experience { get; set; }

        [JsonProperty("prequisites")]
        public List<int> Prequisites { get; set; }

        [JsonProperty("costs")]
        public List<GuildUpgradeCost> Costs { get; set; }

        /** Optional Fields **/

        [JsonProperty("bag_max_items")]
        public int BagMaxItems { get; set; }

        [JsonProperty("bag_max_coinds")]
        public int BagMaxCoins { get; set; }
    }

    public enum GuildUpgradeType
    {
        AccumulatingCurrency,
        BankBag,
        Boost,
        Claimable,
        Consumable,
        Decoration,
        Hub,
        Unlock,
        GuildHall,
        GuildHallExpedition,
        Queue
    }
}
