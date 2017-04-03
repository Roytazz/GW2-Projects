using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class Infusion
    {
        [JsonProperty("item_id")]
        public int ItemID { get; set; }

        [JsonProperty("flags")]
        public List<string> Flags { get; set; }
    }
}