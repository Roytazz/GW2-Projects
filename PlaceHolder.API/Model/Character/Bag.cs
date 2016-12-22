using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
