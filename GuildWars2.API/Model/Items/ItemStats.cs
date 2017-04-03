using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class ItemStats
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attributes")]
        public Dictionary<ItemAttribute, decimal> Attributes { get; set; }
    }
}
