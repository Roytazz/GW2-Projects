using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class Upgrade
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("tiers")]
        public List<UpgradeTier> Tiers { get; set; }
    }
}
