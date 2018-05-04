using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class Infix
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("attributes")]
        public List<InfixAttribute> Attributes { get; set; }

        [JsonProperty("buff")]
        public InfixBuff Buff { get; set; }
    }
}