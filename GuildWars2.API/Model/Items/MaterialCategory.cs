using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class MaterialCategory
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public List<int> Items { get; set; }
    }
}
