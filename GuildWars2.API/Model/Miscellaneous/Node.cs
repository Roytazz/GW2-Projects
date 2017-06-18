using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Node
    {
        [JsonProperty("id")]
        public string ID { get; set; }
    }
}
