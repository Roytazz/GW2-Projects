using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Story
{
    public class StorySeason
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("stories")]
        public List<int> Stories { get; set; }
    }
}
