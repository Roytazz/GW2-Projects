using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class UpgradeTier
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("yaks_required")]
        public int YaksRequired { get; set; }

        [JsonProperty("upgrades")]
        public List<UpgradeTierEntry> Upgrades { get; set; }
    }
}