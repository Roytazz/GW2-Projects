using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Miscellaneous
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
