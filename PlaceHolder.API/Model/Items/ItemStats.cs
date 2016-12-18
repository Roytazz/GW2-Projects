using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Items
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
