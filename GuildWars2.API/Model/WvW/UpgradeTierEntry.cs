using Newtonsoft.Json;

namespace GuildWars2.API.Model.WvW
{
    public class UpgradeTierEntry
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}