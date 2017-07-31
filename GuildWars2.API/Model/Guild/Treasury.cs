using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Guild
{
    public class Treasury
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("needed_by")]
        public List<TreasuryRequiredBy> NeededBy { get; set; }
    }
}