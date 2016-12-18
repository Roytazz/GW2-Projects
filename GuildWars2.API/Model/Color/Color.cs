using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Color
{
    public class Color
    {
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("base_rgb")]
        public List<int> BaseRGB { get; set; }

        [JsonProperty("cloth")]
        public ColorDetails Cloth { get; set; }

        [JsonProperty("leather")]
        public ColorDetails Leather { get; set; }

        [JsonProperty("metal")]
        public ColorDetails Metal { get; set; }
    }
}
