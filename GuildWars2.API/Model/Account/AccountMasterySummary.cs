using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Account
{
    public class AccountMasterySummary
    {
        [JsonProperty("totals")]
        public List<AccountMasteryRegion> Totals { get; set; }

        [JsonProperty("unlocked")]
        public List<int> Unlocked { get; set; }
    }
}
