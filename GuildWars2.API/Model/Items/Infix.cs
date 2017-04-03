using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class Infix
    {
        [JsonProperty("attributes")]
        public List<InfixAttribute> Attributes { get; set; }

        [JsonProperty("buff")]
        public InfixBuff Buff { get; set; }
    }
}