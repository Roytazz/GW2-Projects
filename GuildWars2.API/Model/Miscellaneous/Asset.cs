using Newtonsoft.Json;

namespace GuildWars2API.Model.Miscellaneous
{
    public class Asset
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
