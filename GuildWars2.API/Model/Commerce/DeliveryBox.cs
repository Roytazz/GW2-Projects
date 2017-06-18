using GuildWars2.API.Model.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Model.Commerce
{
    public class DeliveryBox
    {
        [JsonProperty("coins")]
        public int Coins { get; set; }

        [JsonIgnore]
        public ItemPrice Price { get { return new ItemPrice(Coins); } }

        [JsonProperty("items")]
        public List<ItemStack> Items { get; set; }
    }
}
