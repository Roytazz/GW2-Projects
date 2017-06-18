using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Cat
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("hint")]
        public string Hint { get; set; }
    }
}
