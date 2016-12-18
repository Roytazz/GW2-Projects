using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class Finisher
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("unlock_details")]
        public string UnlockDetails { get; set; }

        [JsonProperty("unlock_items")]
        public List<object> UnlockItems { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
