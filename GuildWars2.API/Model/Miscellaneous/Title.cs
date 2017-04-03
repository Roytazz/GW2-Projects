using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Title
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("achievement")]
        public int Achievement { get; set; }
    }
}
