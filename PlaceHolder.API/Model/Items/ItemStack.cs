using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class ItemStack
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
