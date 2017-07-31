using GuildWars2.API.Model.Items;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class InventoryEntity : Equipment
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
