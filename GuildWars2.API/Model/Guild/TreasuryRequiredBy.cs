using Newtonsoft.Json;

namespace GuildWars2.API.Model.Guild
{
    public class TreasuryRequiredBy
    {
        [JsonProperty("upgrade_id")]
        public int UpgradeID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}