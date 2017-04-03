using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Glider
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("unlock_items")]
        public List<int> UnlockItems { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("default_dyes")]
        public List<int> DefaultDyes { get; set; }
    }
}
