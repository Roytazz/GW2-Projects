using Newtonsoft.Json;

namespace GuildWars2API.Model.Items
{
    public class ItemStack
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
