using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class Material
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("binding")]
        public EntityBinding Binding { get; set; }
    }
}
