using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Miscellaneous
{
    public class Asset
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
