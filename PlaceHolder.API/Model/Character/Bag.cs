using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class Bag
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("inventory")]
        public List<BagItem> Inventory { get; set; }
    }
}
