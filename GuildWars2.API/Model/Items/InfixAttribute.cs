using Newtonsoft.Json;

namespace GuildWars2API.Model.Items
{
    public class InfixAttribute
    {
        [JsonProperty("attribute")]
        public ItemAttribute Attribute { get; set; }

        [JsonProperty("modifier")]
        public int Modifier { get; set; }
    }
}