using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Guild
{
    public class TreasuryRequiredBy
    {
        [JsonProperty("upgrade_id")]
        public int UpgradeID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}