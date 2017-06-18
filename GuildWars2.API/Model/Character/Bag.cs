using GuildWars2.API.Model.Items;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Character
{
    public class Bag
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("inventory")]
        public List<InventoryEntity> Inventory { get; set; }
    }
}
